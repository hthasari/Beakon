using BeakonMvvm.Core.Interfaces;
using MvvmCross.Platform;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeakonMvvm.Core.Database
{
    
    class PersonDB : IPersonDB
    {
        private SQLiteConnection database;


        public PersonDB()
        {
            var sqlite = Mvx.Resolve<IDatabase>();
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

        public string Count()
        {
            return database.Query<Person> ("SELECT Count(*) FROM Person").ToString();
        }

    }
    }

