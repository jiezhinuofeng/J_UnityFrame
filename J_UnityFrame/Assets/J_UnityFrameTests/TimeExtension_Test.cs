using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace J_Framework.Utils
{   
    public class TimeExtension_Test
    {
        [Test]
        public void Test_TimeStamp()
        {
            var nowTime = System.DateTime.Now;
            Debug.Log("当前本地时间:" + nowTime);

            var mlong = nowTime.DateTimeToStamp();
            Debug.Log("获取当前时间戳:"+ mlong);
            Debug.Log("当前时间戳转时间:" + mlong.StampToDateTime());

        }
    }
}

