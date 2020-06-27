using UnityEngine;

namespace J_Framework.ResKit
{
    public interface IResLoader
    {
        T Load<T>(string assetPathOrName) where T : Object;

        void UnloadAllAsset();
    }
}

