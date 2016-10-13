using BeakonMvvm.Core.Interfaces;
using MvvmCross.Platform;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

// Author Gurpreet Dhaliwal
namespace BeakonMvvm.Core.Database
{
    
    public class ReqDB : IReqDB
    {
        private SQLiteConnection database;

        public ReqDB()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<Req>();
        }


    public void DeleteReq(object id)
        {
            database.Delete<Req>(Convert.ToInt16(id));
        }

        public List<Req> GetReq()
        {
            return database.Table<Req>().ToList();
        }

        public int InsertReq(Req person)
        {
            var num = database.Insert(person);
            database.Commit();
            return num;
        }

        public string Count()
        {
            return database.Query<Req>("SELECT Count(*) FROM Person").ToString();
        }

    }

}

