using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace J_Framework.ResKit
{
    public class Res : SimpleRc
    {
        //public Res(string assetPathOrName)
        //{
        //    Name = assetPathOrName;
        //}

        public string Name { get; set; }

        public Object Asset { get; set; }

        public void Load()
        {
            Asset = Resources.Load(Name);
        }



        public override void OnZeroRef()
        {
            Resources.UnloadAsset(Asset);

            ResMgr.Instance.RemoveData(Name);
        }
    }
}
