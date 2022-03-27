//#define FILE_DIFF_TEST
using System.Data.SQLite;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DefaultPatcher
{
    /// <summary>
    /// NOTE: ProfileID and ApplicationID GUID's seem to be the same, use either that isn't null
    /// NOTE: If you fail to receive a card from the card LUT, it could be a mouse binding
    /// </summary>
    public partial class Form1 : Form
    {
        public static string MOUSE_BINDS_TAG = "MOUSE_BINDS";
        private string m_LGHUBDataPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\LGHUB\\settings.db";
        private SQLiteConnection m_SQLConnection;
        private ListItem[]? m_listItems;
        private AttributeToggleListItem[]? m_attributeToggleListItems;
        private LGHUB.LGHUBData m_lgHUBData;
        private LGHUB.Profile m_rootSelectedProfile;
        private ListItem m_rootSelectedItem;
        private Dictionary<Guid, LGHUB.Application> m_applicationLUT; // ProfileID/ApplicationID GUID
        private Dictionary<Guid, LGHUB.Card> m_cardLUT; // CardID GUID
        private Dictionary<Guid, ListItem> m_listItemLUT; // ProfileID/ApplicationID GUID

        private JObject? m_loadedJObject;

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

                RefreshItemList();
            }
            else
            {
                MessageBox.Show("Unknown error", "Error");
            }
        }


        #endregion

        private void RefreshItemList()
        {
            // Check we're not still connected to the last opened database
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
                    BuildCardLUT(m_lgHUBData);

                    // Get all unique attributes
                    HashSet<string> attributes = new HashSet<string>();
                    foreach (var item in m_lgHUBData.Cards.CardsCards)
                    {
                        attributes.Add(item.Attribute);
                    }
                    attributes.Add(MOUSE_BINDS_TAG);
                    BuildAttributesList(attributes);

                    BuildApplicationList(m_lgHUBData);

                    BuildListItemLUT();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
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
                if(m_attributeToggleListItems == null)
                {
                    return false;
                }

                // See what attributes we're copying over
                Dictionary<string, bool> attributesToOverwrite = new Dictionary<string, bool>(m_attributeToggleListItems.Length);
                foreach(var item in m_attributeToggleListItems)
                {
                    attributesToOverwrite.Add(item.AttributeName, item.Checked);
                }

                // Grab all attributes to put into the other profiles from root
                List<LGHUB.Assignment> rootAssignments = new List<LGHUB.Assignment>(m_rootSelectedProfile.Assignments.Length);
                foreach(var curAssignment in m_rootSelectedProfile.Assignments)
                {
                    LGHUB.Card? curCard = GetCardFromAssignment(curAssignment);

                    // Mouse binds are valid to be NULL, I hate this
                    if(curCard == null)
                    {
                        if(attributesToOverwrite.TryGetValue(MOUSE_BINDS_TAG, out bool shouldOverwrite) && shouldOverwrite)
                        {
                            rootAssignments.Add(curAssignment);
                        }
                    }
                    else
                    {
                        if (attributesToOverwrite.TryGetValue(curCard.Attribute, out bool shouldOverwrite) && shouldOverwrite)
                        {
                            rootAssignments.Add(curAssignment);
                        }
                    }

                }

                // Copy over assignments
                foreach(ListItem listItem in m_listItems)
                {
                    if (listItem == null || !listItem.OverWrite || listItem.Profile == m_rootSelectedProfile)
                    {
                        continue;
                    }

                    // Overwrite only default profile
                    LGHUB.Profile cur = listItem.Profile;
                    if (cur.Name == "PROFILE_NAME_DEFAULT")
                    {
                        var newAssignments = cur.Assignments.ToList();
                        newAssignments.RemoveAll(assignment =>
                        {
                            LGHUB.Card? curCard = GetCardFromAssignment(assignment);
                            if(curCard == null)
                            {
                                if(attributesToOverwrite.TryGetValue(MOUSE_BINDS_TAG, out bool shouldOverwrite) && shouldOverwrite)
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                if (attributesToOverwrite.TryGetValue(curCard.Attribute, out bool shouldOverwrite) && shouldOverwrite)
                                {
                                    return true;
                                }
                            }

                            return false;
                        });

                        newAssignments.AddRange(rootAssignments);
                        cur.Assignments = newAssignments.ToArray();
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

        private LGHUB.Card? GetCardFromAssignment(LGHUB.Assignment assignment)
        {
            if(m_cardLUT.TryGetValue(assignment.CardId, out var card))
            {
                return card;
            }
            return null;
        }

        private LGHUB.LGHUBData? GetDataFromLGHUB()
        {
            SQLiteCommand cmd = m_SQLConnection.CreateCommand();
            cmd.CommandText = "SELECT file FROM data";

            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();

            string file = reader.GetString(0);

            m_loadedJObject = JObject.Parse(file);
            LGHUB.LGHUBData? data = JsonConvert.DeserializeObject<LGHUB.LGHUBData>(file);

#if FILE_DIFF_TEST
            try
            {
                File.WriteAllText($"{Environment.CurrentDirectory}\\before.json", file);

                string fakeFile = PatchChangesIntoOriginalJSON(data.Profiles);
                File.WriteAllText($"{Environment.CurrentDirectory}\\after.json", fakeFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
#endif

            return data;
        }

        private string PatchChangesIntoOriginalJSON(LGHUB.Profiles profiles)
        {
            if(m_loadedJObject != null)
            {
                if(m_loadedJObject.TryGetValue("profiles", out JToken? rootProfilesToken))
                {
                    string serializedProfilesEdit = JsonConvert.SerializeObject(profiles);
                    JObject editedProfilesToken = JObject.Parse(serializedProfilesEdit);
                    rootProfilesToken.Replace(editedProfilesToken);
                    return m_loadedJObject.ToString(Formatting.Indented, new LGHUB.DoubleFormatConverter());
                }
            }

            return "";
        }

        private bool SaveDataToLGHUB(LGHUB.LGHUBData data)
        {
            if (m_SQLConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string newJSONFile = PatchChangesIntoOriginalJSON(data.Profiles);

#if FILE_DIFF_TEST
                    try
                    {
                        File.WriteAllText($"{Environment.CurrentDirectory}\\after.json", newJSONFile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
#endif

                    SQLiteCommand cmd = m_SQLConnection.CreateCommand();
                    cmd.CommandTimeout = 2;
                    cmd.CommandText = "UPDATE data SET file=@data WHERE _id=@id";
                    cmd.Parameters.AddWithValue("@data", newJSONFile);
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

        private void BuildCardLUT(LGHUB.LGHUBData data)
        {
            m_cardLUT = new Dictionary<Guid, LGHUB.Card>(data.Cards.CardsCards.Length);
            foreach(var card in data.Cards.CardsCards)
            {
                if (card != null && !m_cardLUT.ContainsKey(card.Id))
                {
                    m_cardLUT.Add(card.Id, card);
                }
            }
        }

        private void BuildApplicationList(LGHUB.LGHUBData data)
        {
            // If we already have a list of items, clear it
            if (appList.Controls.Count > 0)
            {
                appList.Controls.Clear();
            }

            m_listItems = new ListItem[m_applicationLUT.Count];
            int i = 0;
            foreach (var curProfile in data.Profiles.ProfilesProfiles)
            {
                ListItem curListItem = new ListItem();
                LGHUB.Application curApplication = m_applicationLUT[curProfile.ApplicationId];
                bool isDesktopProfile = curApplication.Name == "APPLICATION_NAME_DESKTOP";

                // Try load an image for this application
                string imgPath = curApplication.PosterPath;
                if (imgPath == null)
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
                if (!File.Exists(imgPath))
                {
                    imgPath = "";
                }

                // Pass the data to the new item for it to display and setup call back for its radio button
                curListItem.Init(imgPath, curApplication.Name, true, OnNewRootSelected, curProfile);
                curListItem.Dock = DockStyle.Top;
                appList.Controls.Add(curListItem);

                // Desktop profile will exist in all circumstances, use as default
                if (isDesktopProfile)
                {
                    OnNewRootSelected(curListItem);
                }
                m_listItems[i] = curListItem;
                ++i;
            }

        }

        private void BuildAttributesList(HashSet<string> uniqueAttributes)
        {
            // If we already have a list of attributes, clear it
            if (attributeList.Controls.Count > 0)
            {
                attributeList.Controls.Clear();
            }

            int i = 0;
            m_attributeToggleListItems = new AttributeToggleListItem[uniqueAttributes.Count];
            foreach(string attribute in uniqueAttributes)
            {
                AttributeToggleListItem newItem = new AttributeToggleListItem();
                newItem.Init(attribute);
                newItem.Dock = DockStyle.Top;
                attributeList.Controls.Add(newItem);

                m_attributeToggleListItems[i] = newItem;
                ++i;
            }
        }

        private void BuildListItemLUT()
        {
            if(m_listItems == null)
            {
                return;
            }

            m_listItemLUT = new Dictionary<Guid, ListItem>(m_listItems.Length);
            foreach(var item in m_listItems)
            {
                m_listItemLUT.Add(item.Profile.ApplicationId, item);
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

        private void selectAllAttributesBtn_Click(object sender, EventArgs e)
        {
            DoSelectionOnAllAttributes((item) => true);
        }

        private void unselectAllAttributesBtn_Click(object sender, EventArgs e)
        {
            DoSelectionOnAllAttributes((item)=>false);
        }

        private void invertSelectAttributesBtn_Click(object sender, EventArgs e)
        {
            DoSelectionOnAllAttributes((item) => !item.Checked);
        }

        private void DoSelectionOnAllAttributes(Func<AttributeToggleListItem, bool> func)
        {
            if(m_attributeToggleListItems != null)
            {
                foreach(AttributeToggleListItem item in m_attributeToggleListItems)
                {
                    item.SetChecked(func(item));
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

        private void selectAllAppsBtn_Click(object sender, EventArgs e)
        {
            DoSelectionOnAllApps((item) => true);
        }

        private void unselectAppsBtn_Click(object sender, EventArgs e)
        {
            DoSelectionOnAllApps((item) => false);
        }

        private void invertAppBtn_Click(object sender, EventArgs e)
        {
            DoSelectionOnAllApps((item) => !item.OverWrite);
        }

        private void DoSelectionOnAllApps(Func<ListItem, bool> func)
        {
            if (m_listItems != null)
            {
                foreach (ListItem item in m_listItems)
                {
                    item.SetOverWrite(func(item));
                }
            }
        }
    }
}