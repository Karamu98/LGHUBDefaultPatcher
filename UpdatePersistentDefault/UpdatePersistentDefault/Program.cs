using System.Data.SQLite;
using Newtonsoft.Json;


namespace UpdatePersistentDefault // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static string LGHUBDataPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\LGHUB\\settings.db";
        private static SQLiteConnection SQLCONNECTION;

        static void Main(string[] args)
        {
            while(System.Diagnostics.Process.GetProcessesByName("lghub").Length > 0)
            {
                Console.WriteLine("Please close LGHUB before running this tool, then press Enter.");
                Console.ReadLine();
            }

            Console.WriteLine("Set all default profiles to Desktop Default? (y/n)");
            string? input = Console.ReadLine();
            if (input != "y")
            {
                return;
            }

            SQLCONNECTION = new SQLiteConnection("Data Source=" + LGHUBDataPath + ";Version=3;Synchronous=Off;UTF8Encoding=True;");
            SQLCONNECTION.Open();

            try
            {
                LGHUB.LGHUBData? data = GetDataFromLGHUB();
                if (data != null)
                {
                    BuildApplicationLUT(data);
                    BuildMouseSettingsLUT(data);

                    LGHUB.Profile? rootProfile = null;
                    foreach (LGHUB.Profile prof in data.Profiles.ProfilesProfiles)
                    {
                        if (prof.Name == "Desktop Standard")
                        {
                            rootProfile = prof;
                            break;
                        }
                    }

                    if (rootProfile != null)
                    {
                        // Found profile
                        for (int i = 0; i < data.Profiles.ProfilesProfiles.Length; ++i)
                        {
                            LGHUB.Profile cur = data.Profiles.ProfilesProfiles[i];
                            if (cur.Name == "PROFILE_NAME_DEFAULT")
                            {
                                Console.WriteLine($"Replaced {m_applicationLUT[cur.Id].ApplicationPath} default");
                                cur.Assignments = rootProfile.Assignments;
                            }
                        }

                        LGHUB.MouseSettings rootMouseSettings = m_mouseSettingsLUT[rootProfile.ApplicationId];
                        if (rootMouseSettings != null)
                        {
                            for (int i = 0; i < data.Cards.CardsCards.Length; ++i)
                            {
                                LGHUB.Card cur = data.Cards.CardsCards[i];
                                if (cur.MouseSettings != null)
                                {
                                    cur.MouseSettings = rootMouseSettings;
                                }
                            }
                        }
                    }

                    SaveDataToLGHUB(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            SQLCONNECTION.Close();

            Console.WriteLine("Press Enter to close...");
            Console.ReadLine();
        }

        private static LGHUB.LGHUBData? GetDataFromLGHUB()
        {
            SQLiteCommand cmd = SQLCONNECTION.CreateCommand();
            cmd.CommandText = "SELECT file FROM data";

            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();

            string file = reader.GetString(0);

            LGHUB.LGHUBData? data = JsonConvert.DeserializeObject<LGHUB.LGHUBData>(file);

            return data;
        }

        private static void SaveDataToLGHUB(LGHUB.LGHUBData data)
        {
            if(SQLCONNECTION.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    SQLiteCommand cmd = SQLCONNECTION.CreateCommand();
                    cmd.CommandTimeout = 2;
                    cmd.CommandText = "UPDATE data SET file=@data WHERE _id=@id";
                    cmd.Parameters.AddWithValue("@data", JsonConvert.SerializeObject(data));
                    cmd.Parameters.AddWithValue("@id", 1);
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.ErrorCode);
                }
            }
        }

        private static void BuildApplicationLUT(LGHUB.LGHUBData data)
        {
            m_applicationLUT = new Dictionary<Guid, LGHUB.Application>(data.Applications.ApplicationsApplications.Length);
            foreach (LGHUB.Application? app in data.Applications.ApplicationsApplications)
            {
                m_applicationLUT.Add(app.ApplicationId, app);
            }
        }

        private static void BuildMouseSettingsLUT(LGHUB.LGHUBData data)
        {
            m_mouseSettingsLUT = new Dictionary<Guid, LGHUB.MouseSettings>(data.Cards.CardsCards.Length);
            foreach (LGHUB.Card? card in data.Cards.CardsCards)
            {
                if(card.MouseSettings != null && card.ProfileId != null)
                {
                    m_mouseSettingsLUT.Add((Guid)card.ProfileId, card.MouseSettings);
                }
            }
        }

        private static Dictionary<Guid, LGHUB.Application> m_applicationLUT;
        private static Dictionary<Guid, LGHUB.MouseSettings> m_mouseSettingsLUT;
    }
}