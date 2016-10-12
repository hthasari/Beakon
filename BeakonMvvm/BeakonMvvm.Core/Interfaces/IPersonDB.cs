using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeakonMvvm.Core.Interfaces
{
    public interface IPersonDB
    {
       
        List<Person> GetPersons();

        void DeletePerson(object id);

        int InsertPerson(Person person);
        // Task<int> InsertLocation(LocationAutoCompleteResult location);

        string Count();


    }
}
