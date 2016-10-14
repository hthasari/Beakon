using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeakonMvvm.Core.Interfaces
{
    public interface IAnsDB
    {
        List<Answ> GetAns();

        void DeleteAnsw(object id);

        int InsertAns(Answ person);

        // Task<int> InsertLocation(LocationAutoCompleteResult location);

    }
}
