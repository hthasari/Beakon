﻿using BeakonMvvm.Core.Interfaces;
using MvvmCross.Platform;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

// Author Gurpreet Dhaliwal
namespace BeakonMvvm.Core.Database
{
    
    public class AnsDB : IAnsDB
    {
        private SQLiteConnection database;

        public AnsDB()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<Answ>();
        }

    public void DeleteAnsw(object id)
        {
            database.Delete<Answ>(Convert.ToInt16(id));
        }

        public List<Answ> GetAns()
        {
            return database.Table<Answ>().ToList();
        }

        public int InsertAns(Answ person)
        {
            var num = database.Insert(person);
            database.Commit();
            return num;
        }

    }

}

