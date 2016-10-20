using BeakonMvvm.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeakonMvvm.Core.Database
{
    public interface IAPerson
    {
        Task<IEnumerable<Perso>> GetPersons();

        //Task<int> DeletePerson(object id);

        Task<int> InsertPerson(Perso p);
        Task<bool> CheckIfExists(Perso p);


    }
}