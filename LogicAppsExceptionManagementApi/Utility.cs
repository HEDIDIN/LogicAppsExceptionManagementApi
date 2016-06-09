using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicAppsExceptionManagementApi
{
    public static class Utility
    {
        public static double ConvertToTimestamp(DateTime value)
        {

            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            var span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX timestamp)
            return span.TotalSeconds;

        }


    }
}
