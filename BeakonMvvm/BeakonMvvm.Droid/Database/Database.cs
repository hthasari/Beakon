﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using BeakonMvvm.Core.Interfaces;
using SQLite.Net;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;

namespace BeakonMvvm.Droid.Database
{
    public class BDatabase : IDatabase
    {
       public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "LocationSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            var conn = new SQLiteConnection(new SQLitePlatformAndroid(), path);
            // Return the database connection
            return conn;
        }

    }
}
