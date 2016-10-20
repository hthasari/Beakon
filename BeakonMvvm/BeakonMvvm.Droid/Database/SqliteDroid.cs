using BeakonMvvm.Core.Interfaces;
using System.IO;
using SQLite;

namespace BeakonMvvm.Droid.Database
{
    public class SqliteDroid : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "LocationSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }


    }
}