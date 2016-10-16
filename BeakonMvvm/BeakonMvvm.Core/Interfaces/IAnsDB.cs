using System.Collections.Generic;

namespace BeakonMvvm.Core.Interfaces
{
    public interface IAnsDB
    {
        List<Answ> GetAns();

        void DeleteAnsw(object id);

        int InsertAns(Answ person);
    }
}
