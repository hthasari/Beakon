using System.Collections.Generic;

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
