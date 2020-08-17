using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using J_Framework.ResKit;
using System.IO;
using UnityEditor.VersionControl;

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

        //Assert.IsNotNull(testRes.Asset);

        //判断两个状态是否相等
        Assert.AreEqual(ResState.Loaded, testRes.State);        
    }   

    /// <summary>
    /// 加载实际资源
    /// </summary>
    [Test]    
    public void ResLoadTest()
    {
        // 注册自定义类型的 Res
        ResFactory.RegisterCustomRes((address) =>
        {
            if (address.StartsWith("test://"))
            {
                return new TestRes()
                {
                    Name = address
                };
            }

            return null;
        });

        // 测试
        var resLoader = new ResLoader();

        var iconTextureRes = resLoader.LoadRes("test://icon_texture");

        Assert.IsTrue(iconTextureRes is TestRes);
        Assert.AreEqual(1, iconTextureRes.RefCount);
        Assert.AreEqual(ResState.Loaded, iconTextureRes.State);

        resLoader.UnloadAllAsset();

        Assert.AreEqual(0, iconTextureRes.RefCount);
        Assert.AreEqual(ResState.NotLoad, iconTextureRes.State);


        resLoader = null;
    }
}

public class TestRes : Res
{
    public override void Load()
    {
        State = ResState.Loaded;
    }

    public override void UnLoad()
    {
        State = ResState.NotLoad;
    }
}
