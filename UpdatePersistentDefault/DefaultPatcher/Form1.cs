using System.Data.SQLite;
using System.Net;
using Newtonsoft.Json;

namespace DefaultPatcher
{
    public partial class Form1 : Form
    {
        private string m_LGHUBDataPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\LGHUB\\settings.db";
        private SQLiteConnection m_SQLConnection;
        private Dictionary<Guid, LGHUB.Application> m_applicationLUT;
        private Dictionary<Guid, LGHUB.MouseSettings> m_mouseSettingsLUT;
        private ListItem[]? m_listItems;
        private LGHUB.LGHUBData m_lgHUBData;
        private LGHUB.Profile m_rootSelectedProfile;
        private ListItem m_rootSelectedItem;

        public Form1()
        {
            InitializeComponent();

            if(File.Exists(m_LGHUBDataPath))
            {
                dataPath.Text = m_LGHUBDataPath;
            }

            RefreshItemList();
        }

        #region Control

        private void processButton_Click(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("lghub").Length > 0)
            {
                MessageBox.Show("Please close LGHUB before running this tool.", "Error");
                return;
            }

            if (m_lgHUBData == null)
            {
                MessageBox.Show("Please select your settings.db file", "Error");
                return;
            }

            if(m_rootSelectedItem == null)
            {
                MessageBox.Show("Internal error, no root item selected?", "Developer Error");
                return;
            }

            if(m_rootSelectedProfile == null)
            {
                MessageBox.Show("Internal error, no root profile selected?", "Developer Error");
                return;
            }

            if(ProcessUsingProfile())
            {
                MessageBox.Show("Complete.", "Success");
            }
        }


        #endregion

        private void RefreshItemList()
        {
            if(m_listItems != null)
            {
                m_listItems = null;
                appList.Controls.Clear();
            }

            if(m_SQLConnection != null && m_SQLConnection.State == System.Data.ConnectionState.Open)
            {
                m_SQLConnection.Close();
            }

            if(!File.Exists(m_LGHUBDataPath))
            {
                MessageBox.Show($"Couldnt find settings.db file at path ({m_LGHUBDataPath})", "Error");
                return;
            }

            m_SQLConnection = new SQLiteConnection("Data Source=" + m_LGHUBDataPath + ";Version=3;Synchronous=Off;UTF8Encoding=True;");
            m_SQLConnection.Open();

            try
            {
                m_lgHUBData = GetDataFromLGHUB();
                if (m_lgHUBData != null)
                {
                    BuildApplicationLUT(m_lgHUBData);
                    BuildMouseSettingsLUT(m_lgHUBData);

                    m_listItems = new ListItem[m_applicationLUT.Count];
                    int i = 0;
                    foreach(var curProfile in m_lgHUBData.Profiles.ProfilesProfiles)
                    {
                        ListItem curListItem = new ListItem();
                        LGHUB.Application curApplication = m_applicationLUT[curProfile.ApplicationId];
                        bool isDesktopProfile = curApplication.Name == "APPLICATION_NAME_DESKTOP";
                        string imgPath = curApplication.PosterPath;
                        if(imgPath == null)
                        {
                            string imgCacheDir = $"{Path.GetDirectoryName(Environment.ProcessPath)}\\img\\";
                            imgPath = $"{imgCacheDir}{curApplication.Name}.png";
                            if (!File.Exists(imgPath) && !isDesktopProfile)
                            {
                                Uri imgURI = curApplication.PosterUrl;
                                if (imgURI == null)
                                {
                                    imgURI = curApplication.ProfileUrl;
                                }
                                if (imgURI != null)
                                {
                                    using (WebClient webClient = new WebClient())
                                    {
                                        Stream stream = webClient.OpenRead(imgURI);
                                        Bitmap bitmap = new Bitmap(stream);

                                        if (bitmap != null)
                                        {
                                            string savePath = $"{imgCacheDir}{curApplication.Name}.png";
                                            if (!Directory.Exists(imgCacheDir))
                                            {
                                                Directory.CreateDirectory(imgCacheDir);
                                            }

                                            bitmap.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);

                                            imgPath = savePath;
                                        }

                                        stream.Flush();
                                        stream.Close();
                                        webClient.Dispose();
                                    }
                                }

                            }
                        }
                        if(!File.Exists(imgPath))
                        {
                            imgPath = null;
                        }
                        curListItem.Init(imgPath, curApplication.Name, true, OnNewRootSelected, curProfile);
                        curListItem.Dock = DockStyle.Top;
                        appList.Controls.Add(curListItem);
                        if (isDesktopProfile)
                        {
                            OnNewRootSelected(curListItem);
                        }
                        m_listItems[i] = curListItem;
                        ++i;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OnNewRootSelected(ListItem newItem)
        {
            if(newItem == m_rootSelectedItem)
            {
                return;
            }
            m_rootSelectedItem?.SetRoot(false);
            m_rootSelectedItem = newItem;
            m_rootSelectedItem.SetRoot(true);
            m_rootSelectedProfile = m_rootSelectedItem.Profile;
            rootNameDisplay.Text = $"Current Root:\n{newItem.AppName}";
        }

        private bool ProcessUsingProfile()
        {
            try
            {
                // Copy over assignments
                for (int i = 0; i < m_lgHUBData.Profiles.ProfilesProfiles.Length; ++i)
                {
                    LGHUB.Profile cur = m_lgHUBData.Profiles.ProfilesProfiles[i];
                    if (cur.Name == "PROFILE_NAME_DEFAULT")
                    {
                        cur.Assignments = m_rootSelectedProfile.Assignments;
                    }
                }

                // Copy over mouse settings
                LGHUB.MouseSettings rootMouseSettings = m_mouseSettingsLUT[m_rootSelectedProfile.ApplicationId];
                if (rootMouseSettings != null)
                {
                    for (int i = 0; i < m_lgHUBData.Cards.CardsCards.Length; ++i)
                    {
                        LGHUB.Card cur = m_lgHUBData.Cards.CardsCards[i];
                        if (cur.MouseSettings != null)
                        {
                            cur.MouseSettings = rootMouseSettings;
                        }
                    }
                }

                // Commit to database
                return SaveDataToLGHUB(m_lgHUBData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
            return false;
        }

        private LGHUB.LGHUBData? GetDataFromLGHUB()
        {
            SQLiteCommand cmd = m_SQLConnection.CreateCommand();
            cmd.CommandText = "SELECT file FROM data";

            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();

            string file = reader.GetString(0);

            LGHUB.LGHUBData? data = JsonConvert.DeserializeObject<LGHUB.LGHUBData>(file);

            return data;
        }

        private bool SaveDataToLGHUB(LGHUB.LGHUBData data)
        {
            if (m_SQLConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    SQLiteCommand cmd = m_SQLConnection.CreateCommand();
                    cmd.CommandTimeout = 2;
                    cmd.CommandText = "UPDATE data SET file=@data WHERE _id=@id";
                    cmd.Parameters.AddWithValue("@data", JsonConvert.SerializeObject(data));
                    cmd.Parameters.AddWithValue("@id", 1);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
            }
            return false;
        }
        private void BuildApplicationLUT(LGHUB.LGHUBData data)
        {
            m_applicationLUT = new Dictionary<Guid, LGHUB.Application>(data.Applications.ApplicationsApplications.Length);
            foreach (LGHUB.Application? app in data.Applications.ApplicationsApplications)
            {
                m_applicationLUT.Add(app.ApplicationId, app);
            }
        }

        private void BuildMouseSettingsLUT(LGHUB.LGHUBData data)
        {
            m_mouseSettingsLUT = new Dictionary<Guid, LGHUB.MouseSettings>(data.Cards.CardsCards.Length);
            foreach (LGHUB.Card? card in data.Cards.CardsCards)
            {
                if (card.MouseSettings != null && card.ProfileId != null)
                {
                    m_mouseSettingsLUT.Add((Guid)card.ProfileId, card.MouseSettings);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(m_SQLConnection != null && m_SQLConnection.State != System.Data.ConnectionState.Closed)
            {
                m_SQLConnection.Close();
            }
        }

        private void selectAllBtn_Click(object sender, EventArgs e)
        {
            DoSelectionOnAll((item) => true);
        }

        private void unselectAllBtn_Click(object sender, EventArgs e)
        {
            DoSelectionOnAll((item)=>false);
        }

        private void invertSelectBtn_Click(object sender, EventArgs e)
        {
            DoSelectionOnAll((item) => !item.OverWrite);
        }

        private void DoSelectionOnAll(Func<ListItem, bool> func)
        {
            if(m_listItems != null)
            {
                foreach (ListItem item in m_listItems)
                {
                    item.SetOverWrite(func(item));
                }
            }
        }

        private void dataPath_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                m_LGHUBDataPath = dataPath.Text;
                RefreshItemList();
            }
        }

        private void browseDataPath_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataPath.Text = openFileDialog1.FileName;
                m_LGHUBDataPath = dataPath.Text;
                RefreshItemList();
            }
        }
    }
}