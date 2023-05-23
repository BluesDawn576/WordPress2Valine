using System;

namespace WordPress2Valine.Utils
{
    class TimeConvert
    {
        public static string Format(string time)
        {
            DateTime Otime = Convert.ToDateTime(time);
            string t = Otime.ToString("yyyy-MM-ddTHH:mm:ss.000Z");
            return t;
        }
    }
}
