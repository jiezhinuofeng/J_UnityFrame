using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using J_Framework.ResKit;

public class ResKit_Test
{
    [Test]
    public void LoadRes()
    {
        TestRes testRes = new TestRes()
        {
            Name = "mRes"
        };
        testRes.Load();

        Assert.IsNotNull(testRes.Asset);
    }
}

public class TestRes : Res
{
    
}
