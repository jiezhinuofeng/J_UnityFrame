using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DictionaryExtension
{


    /// <summary>
    /// 获取字典数据
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="Tvalue"></typeparam>
    /// <param name="dic"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static Tvalue TryGet<Tkey,Tvalue>(this Dictionary<Tkey,Tvalue> dic,Tkey key)
    {
        dic.TryGetValue(key, out Tvalue value);
        return value;
    }

    /// <summary>
    /// 增加数据
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="Tvalue"></typeparam>
    /// <param name="dic"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// 字典中没有该数据,则新增
    /// 有该数据,则更新
    public static void AddData<Tkey,Tvalue>(this Dictionary<Tkey,Tvalue> dic, Tkey key,Tvalue value)
    {
        if(dic.ContainsKey(key))
        {
            dic[key] = value;
        }
        else
        {
            dic.Add(key, value);
        }
    }
}
