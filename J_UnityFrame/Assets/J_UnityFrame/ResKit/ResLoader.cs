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
            Res res = null;
            if (mDic_LoadedRes.TryGetValue(assetPathOrName, out res))
            {
                return res.Asset as T;
            }

            res = ResMgr.Instance.GetRes(assetPathOrName);
            if (res != null)
            {
                res.Retain();

                mDic_LoadedRes.Add(res.Name, res);

                return res.Asset as T;
            }

            res = new Res()
            {
                Name = assetPathOrName
            };
            res.Load();
            res.Retain();
            mDic_LoadedRes.Add(res.Name, res);
            ResMgr.Instance.AddData(res.Name, res);

            return res.Asset as T;
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
