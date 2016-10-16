using System.Collections.Generic;

namespace BeakonMvvm.Core.Interfaces
{
    public interface IReqDB
    {
       
        List<Req> GetReq();

        void DeleteReq(object id);

        int InsertReq(Req person);
        // Task<int> InsertLocation(LocationAutoCompleteResult location);

        string Count();


    }
}
