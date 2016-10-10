using Android.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeakonMvvm.Core.Interfaces
{
    public interface ICalendar
    {
        void listCalendar();

        ICursor eventList(int _calId);
    }


}
