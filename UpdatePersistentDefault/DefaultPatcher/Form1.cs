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

        private CoreData m_coreData = new CoreData();
        private GeneratedData m_generatedData = new GeneratedData();

        private LGHUB.Profile m_rootSelectedProfile;
        private ApplicationListItem m_rootSelectedItem;


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

        private bool RefreshItemList()
        {
            try
            {
                // Don't reload if no changes
                CoreData newCoreData = new CoreData();
                newCoreData.Load(m_LGHUBDataPath);
                if(m_coreData.Equals(newCoreData))
                {
                    newCoreData.Reset();
                    return false;
                }

                // Load/Gen data
                m_coreData.Load(m_LGHUBDataPath);
                bool validLoad = m_coreData.IsValid;
                if (validLoad)
                {
                    // Generate new data
                    m_generatedData.Load(m_coreData, OnNewRootSelected);
                    validLoad &= m_generatedData.IsValid;
                }
                else
                {
                    // Clear generated data
                    m_generatedData.Reset();
                }

                // Update views
                appList.Controls.Clear();
                attributeList.Controls.Clear();
                if (validLoad)
                {
                    AddListItemsToPanel(appList, m_generatedData.ApplicationListItems);
                    AddListItemsToPanel(attributeList, m_generatedData.AttributeListItems);
                }

                // Update tool buttons
                fromLoadedToolStripMenuItem.Enabled = validLoad;
                injectLoadedToolStripMenuItem.Enabled = validLoad;
                saveToolStripMenuItem.Enabled = validLoad;
                loadToolStripMenuItem.Enabled = validLoad;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return false;
        }

        private void AddListItemsToPanel(Panel rootPanel, UserControl[] items)
        {
            foreach(UserControl? item in items)
            {
                item.Dock = DockStyle.Top;
                rootPanel.Controls.Add(item);
            }
        }

        private void OnNewRootSelected(ApplicationListItem newItem)
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
                LGHUB.Profile[]? changes = m_generatedData.GetProfileChanges(m_rootSelectedProfile);
                if(changes != null)
                {
                    // Commit to database
                    return m_coreData.Save(changes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
            return false;
        }

        private void ClearViewData(Panel panel)
        {
            if(panel.Controls.Count > 0)
            {
                panel.Controls.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_coreData.Reset();
        }

        private void selectAllAttributesBtn_Click(object sender, EventArgs e)
        {
            m_generatedData.DoSelectionOnAllAttributes((item) => true);
        }

        private void unselectAllAttributesBtn_Click(object sender, EventArgs e)
        {
            m_generatedData.DoSelectionOnAllAttributes((item)=>false);
        }

        private void invertSelectAttributesBtn_Click(object sender, EventArgs e)
        {
            m_generatedData.DoSelectionOnAllAttributes((item) => !item.Checked);
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
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            openFileDialog1.FileName = "settings.db";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataPath.Text = openFileDialog1.FileName;
                m_LGHUBDataPath = dataPath.Text;
                RefreshItemList();
            }
        }

        private void selectAllAppsBtn_Click(object sender, EventArgs e)
        {
            m_generatedData.DoSelectionOnAllApps((item) => true);
        }

        private void unselectAppsBtn_Click(object sender, EventArgs e)
        {
            m_generatedData.DoSelectionOnAllApps((item) => false);
        }

        private void invertAppBtn_Click(object sender, EventArgs e)
        {
            m_generatedData.DoSelectionOnAllApps((item) => !item.OverWrite);
        }

        private void fromLoadedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.FileName = "output.db";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(!m_coreData.IsValid)
                {
                    return;
                }

                File.WriteAllText(saveFileDialog1.FileName, m_coreData.LoadedJSON);
            }
        }

        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.FileName = "settings.db";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CoreData newData = new CoreData();
                newData.Load(openFileDialog1.FileName);
                if(newData.IsValid)
                {
                    saveFileDialog1.InitialDirectory = openFileDialog1.InitialDirectory;
                    saveFileDialog1.FileName = "output.json";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, newData.LoadedJSON);

                        MessageBox.Show($"Successfully extracted JSON from ({openFileDialog1.FileName}) to ({saveFileDialog1.FileName})");
                        return;
                    }
                }
            }

            MessageBox.Show("Failed", "Error");
        }


        private class CoreData
        {
            public CoreData()
            {
                List<System.Reflection.MemberInfo> members = typeof(CoreData).GetMembers(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).ToList();
                members.RemoveAll(m => m.MemberType != System.Reflection.MemberTypes.Field || m.Name == "m_allProperties");
                m_allProperties = members.ToArray();
            }

            public LGHUB.LGHUBData? LGHUBData
            {
                get
                {
                    if(IsValid)
                    {
                        return m_LGHUBData;
                    }

                    return null;
                }
            }

            public string? LoadedJSON
            {
                get
                {
                    if(IsValid)
                    {
                        return m_loadedJSONFile;
                    }

                    return null;
                }
            }

            public bool IsValid
            {
                get
                {
                    foreach (var prop in m_allProperties)
                    {
                        object? value = ((System.Reflection.FieldInfo)prop).GetValue(this);
                        if (value == null)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            public void Load(string dataPath)
            {
                Reset();

                if(!File.Exists(dataPath))
                {
                    return;
                }

                m_SQLConnection = new SQLiteConnection("Data Source=" + dataPath + ";Version=3;Synchronous=Off;UTF8Encoding=True;");
                try
                {
                    m_SQLConnection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if(m_SQLConnection.State != System.Data.ConnectionState.Open)
                {
                    m_SQLConnection.Close();
                    m_SQLConnection = null;
                    return;
                }

                SQLiteCommand cmd = m_SQLConnection.CreateCommand();
                cmd.CommandText = "SELECT file FROM data";

                SQLiteDataReader reader = cmd.ExecuteReader();
                reader.Read();

                m_loadedJSONFile = reader.GetString(0);

                m_loadedJObject = JObject.Parse(m_loadedJSONFile);
                m_LGHUBData = JsonConvert.DeserializeObject<LGHUB.LGHUBData>(m_loadedJSONFile);

                // Done with connection for now, close it
                m_SQLConnection.Close();
            }

            public override bool Equals(object? obj)
            {
                CoreData other = (CoreData)obj;
                if (IsValid && other.IsValid)
                {
                    return m_loadedJSONFile.Equals(other.m_loadedJSONFile);
                }
                return false;
            }

            public bool Save(LGHUB.Profile[] newProfiles)
            {
                if(!IsValid)
                {
                    Reset();
                    return false;
                }

                try
                {
                    m_LGHUBData.Profiles.ProfilesProfiles = newProfiles;
                    if (m_loadedJObject.TryGetValue("profiles", out JToken? rootProfilesToken))
                    {
                        string serializedProfilesEdit = JsonConvert.SerializeObject(m_LGHUBData.Profiles);
                        JObject editedProfilesToken = JObject.Parse(serializedProfilesEdit);
                        rootProfilesToken.Replace(editedProfilesToken);

                        string newJSONFile = m_loadedJObject.ToString(Formatting.Indented, new LGHUB.DoubleFormatConverter());

                        // Attempt reopen connection here
                        m_SQLConnection.Open();
                        if(m_SQLConnection.State == System.Data.ConnectionState.Open)
                        {
                            SQLiteCommand cmd = m_SQLConnection.CreateCommand();
                            cmd.CommandTimeout = 2;
                            cmd.CommandText = "UPDATE data SET file=@data WHERE _id=@id";
                            cmd.Parameters.AddWithValue("@data", newJSONFile);
                            cmd.Parameters.AddWithValue("@id", 1);
                            cmd.ExecuteNonQuery();

                            m_SQLConnection.Close();
                            return true;
                        }
                    }

                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }

                return false;
            }

            public void Reset()
            {
                if(m_SQLConnection != null && m_SQLConnection.State != System.Data.ConnectionState.Closed)
                {
                    m_SQLConnection.Close();
                }

                m_SQLConnection = null;
                m_LGHUBData = null;
                m_loadedJObject = null;
                m_loadedJSONFile = null;
            }

            private LGHUB.LGHUBData? m_LGHUBData;
            private JObject? m_loadedJObject;
            private string? m_loadedJSONFile;
            private SQLiteConnection? m_SQLConnection;

            System.Reflection.MemberInfo[] m_allProperties;
        }

        /// <summary>
        /// This class generates data using CoreData
        /// </summary>
        private class GeneratedData
        {
            public GeneratedData()
            {
                List<System.Reflection.MemberInfo> members = typeof(GeneratedData).GetMembers(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).ToList();
                members.RemoveAll(m => m.MemberType != System.Reflection.MemberTypes.Field || m.Name == "m_allProperties");
                m_allProperties = members.ToArray();
            }

            public ApplicationListItem[]? ApplicationListItems
            {
                get
                {
                    if(IsValid)
                    {
                        return m_applicationListItems;
                    }

                    return null;
                }
            }

            public AttributeToggleListItem[]? AttributeListItems
            {
                get
                {
                    if (IsValid)
                    {
                        return m_attributeToggleListItems;
                    }

                    return null;
                }
            }

            public bool IsValid
            {
                get
                {
                    foreach(var prop in m_allProperties)
                    {
                        if(prop == null)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            public void DoSelectionOnAllAttributes(Func<AttributeToggleListItem, bool> func)
            {
                if (m_attributeToggleListItems != null)
                {
                    foreach (AttributeToggleListItem item in m_attributeToggleListItems)
                    {
                        item.SetChecked(func(item));
                    }
                }
            }

            public void DoSelectionOnAllApps(Func<ApplicationListItem, bool> func)
            {
                if (m_applicationListItems != null)
                {
                    foreach (ApplicationListItem item in m_applicationListItems)
                    {
                        item.SetOverWrite(func(item));
                    }
                }
            }

            public void Load(CoreData m_coreData, Action<ApplicationListItem> onNewRootSelected)
            {
                Reset();

                LGHUB.LGHUBData? data = m_coreData.LGHUBData;
                if(data == null)
                {
                    return;
                }

                BuildApplicationLUT(data);
                BuildCardLUT(data);

                // Get all unique attributes
                HashSet<string> attributes = new HashSet<string>();
                foreach (var item in data.Cards.CardsCards)
                {
                    attributes.Add(item.Attribute);
                }
                attributes.Add(MOUSE_BINDS_TAG);
                BuildAttributesList(attributes);
                BuildApplicationList(data, onNewRootSelected);

                BuildListItemLUT();
            }

            public LGHUB.Profile[]? GetProfileChanges(LGHUB.Profile rootProfile)
            {
                if(!IsValid)
                {
                    return null;
                }

                // See what attributes we're copying over
                Dictionary<string, bool> attributesToOverwrite = new Dictionary<string, bool>(m_attributeToggleListItems.Length);
                foreach (var item in m_attributeToggleListItems)
                {
                    attributesToOverwrite.Add(item.AttributeName, item.Checked);
                }

                // Grab all attributes to put into the other profiles from root
                List<LGHUB.Assignment> rootAssignments = new List<LGHUB.Assignment>(rootProfile.Assignments.Length);
                foreach (var curAssignment in rootProfile.Assignments)
                {
                    LGHUB.Card? curCard = GetCardFromAssignment(curAssignment);

                    // Mouse binds are valid to be NULL, I hate this
                    if (curCard == null)
                    {
                        if (attributesToOverwrite.TryGetValue(MOUSE_BINDS_TAG, out bool shouldOverwrite) && shouldOverwrite)
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

                List<LGHUB.Profile> changes = new List<LGHUB.Profile>();
                IEnumerable<ApplicationListItem>? ignoreList = m_applicationListItems.Where((appListItem) =>
                {
                    bool toIgnore = appListItem == null || !appListItem.OverWrite || appListItem.Profile == null || appListItem.Profile == rootProfile || appListItem.Profile.Name != "PROFILE_NAME_DEFAULT";
                    return toIgnore;
                });

                // Copy over assignments
                foreach (ApplicationListItem curApplicationListItem in m_applicationListItems)
                {
                    if (ignoreList.Contains(curApplicationListItem))
                    {
                        changes.Add(curApplicationListItem.Profile);
                        continue;
                    }

                    // Overwrite only default profile
                    LGHUB.Profile curProfile = curApplicationListItem.Profile;
                    var newAssignments = curProfile.Assignments.ToList();
                    newAssignments.RemoveAll(assignment =>
                    {
                        LGHUB.Card? curCard = GetCardFromAssignment(assignment);
                        if (curCard == null)
                        {
                            if (attributesToOverwrite.TryGetValue(MOUSE_BINDS_TAG, out bool shouldOverwrite) && shouldOverwrite)
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
                    curProfile.Assignments = newAssignments.ToArray();

                    changes.Add(curApplicationListItem.Profile);
                }

                return changes.ToArray();
            }

            public void Reset()
            {
                m_cardLUT = null;
                m_applicationLUT = null;
                m_applicationListItemLUT = null;
                m_applicationListItems = null;
                m_attributeToggleListItems = null;
            }

            private void BuildAttributesList(HashSet<string> uniqueAttributes)
            {
                int i = 0;
                m_attributeToggleListItems = new AttributeToggleListItem[uniqueAttributes.Count];
                foreach (string attribute in uniqueAttributes)
                {
                    AttributeToggleListItem newItem = new AttributeToggleListItem();
                    newItem.Init(attribute);

                    m_attributeToggleListItems[i] = newItem;
                    ++i;
                }
            }

            private void BuildApplicationList(LGHUB.LGHUBData data, Action<ApplicationListItem> onNewRootSelected)
            {
                m_applicationListItems = new ApplicationListItem[m_applicationLUT.Count];
                int i = 0;
                foreach (var curProfile in data.Profiles.ProfilesProfiles)
                {
                    ApplicationListItem curListItem = new ApplicationListItem();
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
                    curListItem.Init(imgPath, curApplication.Name, true, onNewRootSelected, curProfile);

                    // Desktop profile will exist in all circumstances, use as default
                    if (isDesktopProfile)
                    {
                        onNewRootSelected(curListItem);
                    }
                    m_applicationListItems[i] = curListItem;
                    ++i;
                }

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
                foreach (var card in data.Cards.CardsCards)
                {
                    if (card != null && !m_cardLUT.ContainsKey(card.Id))
                    {
                        m_cardLUT.Add(card.Id, card);
                    }
                }
            }

            private void BuildListItemLUT()
            {
                m_applicationListItemLUT = new Dictionary<Guid, ApplicationListItem>(m_applicationListItems.Length);
                foreach (var item in m_applicationListItems)
                {
                    m_applicationListItemLUT.Add(item.Profile.ApplicationId, item);
                }
            }

            private LGHUB.Card? GetCardFromAssignment(LGHUB.Assignment assignment)
            {
                if (m_cardLUT.TryGetValue(assignment.CardId, out var card))
                {
                    return card;
                }
                return null;
            }



            private Dictionary<Guid, LGHUB.Card>? m_cardLUT; // CardID GUID
            private Dictionary<Guid, LGHUB.Application>? m_applicationLUT; // ProfileID/ApplicationID GUID
            private Dictionary<Guid, ApplicationListItem>? m_applicationListItemLUT; // ProfileID/ApplicationID GUID
            private ApplicationListItem[]? m_applicationListItems;
            private AttributeToggleListItem[]? m_attributeToggleListItems;

            System.Reflection.MemberInfo[] m_allProperties;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if(RefreshItemList())
            {
                MessageBox.Show("Changes detected, reloaded", "Info");
            }
        }
    }
}