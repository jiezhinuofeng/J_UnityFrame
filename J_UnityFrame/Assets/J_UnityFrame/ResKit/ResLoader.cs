using J_Framework.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using UnityEngine;

namespace J_Framework.ResKit
{
    public class ResLoader : IResLoader
    {
        private Dictionary<string, Res> mDic_LoadedRes = new Dictionary<string, Res>();

        public T Load<T>(string assetPathOrName) where T : Object
        {
            var res = LoadRes(assetPathOrName);

            if(res==null)
            {
                Debug.LogError("不存在的资源类型:" + assetPathOrName);
                return null;
            }

            return res.Asset as T;
        }

        public Res LoadRes(string address)
        {
            Res res = null;

            //先判断当前脚本有没有加载过资源,加载过则直接返回
            if(mDic_LoadedRes.TryGetValue(address,out res))
            {
                return res;
            }

            //如果当前脚本没有加载过该资源,则判断资源共享池是否加载过(其他脚本是否正在使用资源)
            res = ResMgr.Instance.GetRes(address);
            if(res!=null)
            {
                res.Retain();
                //记录到当前的脚本记录中
                mDic_LoadedRes.Add(res.Name, res);

                return res;
            }
            //如果都未记录,则通过ResFactory.Creat 创建资源
            res = ResFactory.Creat(address);
            if (res == null) return null;
            //做加载操作
            res.Load();
            //记录到资源共享池中
            ResMgr.Instance.AddData(address, res);
            //记录到当前的脚本记录中
            res.Retain();
            mDic_LoadedRes.Add(res.Name, res);

            return res;
        }

        public void UnloadAllAsset()
        {            

            foreach (var item in mDic_LoadedRes)
            {
                item.Value.Release();
            }
            mDic_LoadedRes.Clear();
        }
    }
}
