using BindKit.Binding.Registry;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SimpleRc : IRefCounter
{
    public SimpleRc()
    {
        RefCount = 0;//构造初始化:清零
    }

    public int RefCount { get; private set; }

    public void Retain()
    {
        RefCount += 1;
    }

    public void Release()
    {
        RefCount -= 1;
        if(RefCount==0)
        {
            OnZeroRef();
        }
    }

    /// <summary>
    /// 当计数清零时
    /// </summary>
    public virtual void OnZeroRef()
    {

    }
}
