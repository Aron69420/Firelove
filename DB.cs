using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;

namespace DB_verknüpfen
{
    public class User
    {
        public int UserID { get; set; }
        public string name { get; set; }
        public int Alter { get; set; }
        public int GenderID { get; set; }
    }
    public static class db
    {
        public static void DBLoad()
        {
            // Dateipfad zu Datenbank
            string connectionString = @"Data Source=..\..\..\..\FireLove20.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                connection.Open();
                // Name aus der Tabelle User auswählen
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM User";
                cmd.CommandType = System.Data.CommandType.Text;
                //cmd.CommandText = "PRAGMA table_info(User)";
                var reader = cmd.ExecuteReader();
                List<string> list = new();
                List<User> userlist = new List<User>();
            
                while (reader.Read())
                {
                    User user = new User
                    {
                        UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                        name = reader.GetString(reader.GetOrdinal("Name")),
                        Alter = reader.GetInt32(reader.GetOrdinal("Alter")),
                        GenderID = reader.GetInt32(reader.GetOrdinal("GenderID")),

                        // Fügen Sie hier weitere Eigenschaften hinzu, falls vorhanden
                    };
                    Debug.WriteLine($"UserID: {user.UserID}, Name: {user.name}, Alter: {user.Alter}, GenderID: {user.GenderID}");

                    userlist.Add(user);
                }
                    
                    connection.Close();
                Debug.WriteLine(userlist[1].name);
            }


        }
    }
}
