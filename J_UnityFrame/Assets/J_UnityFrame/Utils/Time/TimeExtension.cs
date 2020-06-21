using System;

namespace J_Framework.Utils
{    

    public static class TimeExtension
    {
        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns></returns>
        /// 获取的数值是本地计算机设置的时间
        public static long GetNowTimeStamp()
        {
            return GetTimeStamp(DateTime.UtcNow);
        }

        /// <summary>
        /// DateTime类型转时间戳
        /// </summary>
        /// <param name="mDateTime"></param>
        /// <returns></returns>
        public static long DateTimeToStamp(this DateTime mDateTime)
        {
            return GetTimeStamp(mDateTime);
        }

        /// <summary>
        /// 时间戳转DateTime
        /// </summary>
        /// <param name="mStamp"></param>
        /// <returns></returns>
        public static DateTime StampToDateTime(this long mStamp)
        {
            System.DateTime Time = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            DateTime dateTime = Time.AddMilliseconds(mStamp);
            return dateTime;
        }


        /// <summary>
        /// 获取时间戳
        /// </summary>        
        /// <param name="bflag"></param>
        /// <returns></returns>
        private static long GetTimeStamp(DateTime dateTime)
        {
            System.DateTime Time = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long TimeStamp = (dateTime.Ticks - Time.Ticks) / 10000;   //除10000调整为13位     
            return TimeStamp;
        }
    }
}
