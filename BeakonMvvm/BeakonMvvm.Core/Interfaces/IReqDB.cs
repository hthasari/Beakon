using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
