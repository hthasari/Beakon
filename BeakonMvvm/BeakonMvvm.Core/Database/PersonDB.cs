using BeakonMvvm.Core.Interfaces;
using MvvmCross.Platform;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

// Author Gurpreet Dhaliwal
namespace BeakonMvvm.Core.Database
{
    
    public class PersonDB : IPersonDB
    {
        private SQLiteConnection database;

        public PersonDB()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<Person>();
        }

        public void DeletePerson(object id)
        {
            database.Delete<Person>(Convert.ToInt16(id));
        }

        public List<Person> GetPersons()
        {
            return database.Table<Person>().ToList();
        }

        public int InsertPerson(Person person)
        {
            var num = database.Insert(person);
            database.Commit();
            return num;
        }

    }

}

