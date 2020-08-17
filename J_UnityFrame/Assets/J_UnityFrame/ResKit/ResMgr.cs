using J_Framework.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

namespace J_Framework.ResKit
{
    public class ResMgr
    {
        private static ResMgr mInstace;
        public static ResMgr Instance
        {
            get
            {
                if (mInstace == null)
                {
                    mInstace = new ResMgr();
                }
                return mInstace;
            }
        }

        private Dictionary<string, Res> mDic_Res = new Dictionary<string, Res>();
       

        public void AddData(string assetPathOrName, Res res)
        {
            if (mDic_Res.ContainsKey(assetPathOrName)) return;

            mDic_Res.Add(assetPathOrName, res);
        }

        public void RemoveData(string assetPathOrName)
        {
            if (!mDic_Res.ContainsKey(assetPathOrName)) return;

            mDic_Res.Remove(assetPathOrName);
        }

        public Res GetRes(string assetPathOrName)
        {
            return mDic_Res.TryGet(assetPathOrName);
        }
    }
}
