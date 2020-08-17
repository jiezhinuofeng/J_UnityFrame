using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace J_Framework.ResKit
{
    public enum ResState
    {
        NotLoad=0,
        Loading=1,
        Loaded=2,
    }

    public class Res : SimpleRc
    {
        public ResState State { get; protected set; }

        public string Name { get; set; }

        public Object Asset { get; set; }

        public virtual void Load()
        {
            Asset = Resources.Load(Name);
        }

        public virtual void UnLoad()
        {
            Resources.UnloadAsset(Asset);
        }



        public override void OnZeroRef()
        {
            UnLoad();

            ResMgr.Instance.RemoveData(Name);
        }
    }
}
