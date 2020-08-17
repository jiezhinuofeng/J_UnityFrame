using J_Framework.ResKit;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using UnityEngine;

public class Mono_Test : MonoBehaviour
{
    ResLoader mResload;
    void Start()
    {
        mResload = new ResLoader();
        var obj= mResload.Load<GameObject>("mRes");
        Instantiate(obj);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.C))
        {
            mResload.UnloadAllAsset();           
        }

        if(Input.GetKeyUp(KeyCode.G))
        {
            mResload.Load<GameObject>("mRes");
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            mResload.Load<GameObject>("mRes");
        }
    }
}
