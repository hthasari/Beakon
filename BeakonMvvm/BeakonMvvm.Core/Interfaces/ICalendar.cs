//using Android.Database;
using System.Collections.Generic;

namespace BeakonMvvm.Core.Interfaces
{
    public interface ICalendar
    {
        List<string> returnEvents();

        //ICursor eventList(int _calId);
    }


}
