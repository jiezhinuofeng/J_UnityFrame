using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace J_Framework.Utils
{
    /// <summary>
    /// 分辨路检测
    /// </summary>
    public class ResolutionCheck
    {
        /// <summary>
        /// 是否横屏
        /// </summary>
        /// <returns></returns>
        public static bool IsLandscape
        {
            get
            {
                return Screen.width > Screen.height;
            }            
        }
    }
}
