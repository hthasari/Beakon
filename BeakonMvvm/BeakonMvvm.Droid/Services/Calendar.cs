using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BeakonMvvm.Core.Interfaces;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;
using Android.Database;
using Android.Graphics;
using static Java.Text.Normalizer;

namespace BeakonMvvm.Droid.Services
{
    
    public class Calendar : ICalendar
    {
        List<string> eventlist = new List<string>();
        public List<string> returnEvents()
        {
            

            // Get events
            var calendarsUri = CalendarContract.Calendars.ContentUri;

            string[] calendarsProjection = {
               CalendarContract.Calendars.InterfaceConsts.Id,
               CalendarContract.Calendars.InterfaceConsts.CalendarDisplayName,
               CalendarContract.Calendars.InterfaceConsts.AccountName
            };

            var cursor = Application.Context.ContentResolver.Query(calendarsUri, calendarsProjection, null, null, null);

            cursor.MoveToPosition(0);
            int calId = cursor.GetInt(cursor.GetColumnIndex(calendarsProjection[0]));

            var events = eventList(calId);


            long eventTimeLong = events.GetLong(2);
            DateTime eventTimeDate = new DateTime(1970, 1, 1, 0, 0, 0,
                DateTimeKind.Utc).AddMilliseconds(eventTimeLong).ToLocalTime();

            DateTime now = DateTime.Now.ToLocalTime();

            while (true)
            {
                 eventTimeLong = events.GetLong(2);
                 eventTimeDate = new DateTime(1970, 1, 1, 0, 0, 0,
                    DateTimeKind.Utc).AddMilliseconds(eventTimeLong).ToLocalTime();

                if (eventTimeDate.DayOfYear.Equals(now.DayOfYear))

                {

                    
                    eventlist.Add(events.ToString());

                    if (events.IsLast == true)
                    {
                        break;
                    }
                    else
                    {
                        events.MoveToNext();
                    }
                  
                }
                else
                {
                    if (events.IsLast == true)
                    {
                        break;
                    }
                    else
                    {
                        events.MoveToNext();
                    }
                }
            }

            return eventlist;

        }

        public ICursor eventList(int _calId)
        {
            var eventsUri = CalendarContract.Events.ContentUri;

            string[] eventsProjection = {
                CalendarContract.Events.InterfaceConsts.Id,
                CalendarContract.Events.InterfaceConsts.Title,
                CalendarContract.Events.InterfaceConsts.Dtstart
             };

            var cursor = Application.Context.ContentResolver.Query(eventsUri, eventsProjection,
             String.Format("calendar_id={0}", _calId), null, "dtstart ASC");

            return cursor;
        } 

    }
}