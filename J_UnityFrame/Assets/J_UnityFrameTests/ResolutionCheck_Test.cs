using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using J_Framework.Utils;
using System.Reflection;
using NUnit.Framework;

public class ResolutionCheck_Test
{
    [Test]
    public void IsLandscape()
    {
        Debug.Log("判断是否横屏：" + ResolutionCheck.IsLandscape);
    }
}
