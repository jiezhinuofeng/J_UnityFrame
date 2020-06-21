using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class CanvasGroupExtension
{
    public static void Show(this CanvasGroup mcanvasGroup)
    {
        MShow(mcanvasGroup);
    }

    public static void Hide(this CanvasGroup mcanvasGroup)
    {
        MHide(mcanvasGroup);
    }


    public static void Show_CanvasGroup(this Transform mtransform)
    {
        if(mtransform.gameObject.activeSelf)
        {
            Debug.LogWarning("当前物体处于未激活状态...");
        }

        var mcanvasGroup = mtransform.GetComponent<CanvasGroup>();
        if(mcanvasGroup==null)
        {
            mcanvasGroup = mtransform.gameObject.AddComponent<CanvasGroup>();
        }
        MShow(mcanvasGroup);
    }

    public static void Hide_CanvasGoup(this Transform mtransform)
    {
        if (mtransform.gameObject.activeSelf)
        {
            Debug.LogWarning("当前物体处于未激活状态...");
        }

        var mcanvasGroup = mtransform.GetComponent<CanvasGroup>();
        if (mcanvasGroup == null)
        {
            mcanvasGroup = mtransform.gameObject.AddComponent<CanvasGroup>();
        }
        MHide(mcanvasGroup);
    }


    private static void MShow(this CanvasGroup mcanvasGroup)
    {
        mcanvasGroup.alpha = 1;
        mcanvasGroup.interactable = true;
        mcanvasGroup.blocksRaycasts = true;
    }

    private static void MHide(this CanvasGroup mcanvasGroup)
    {
        mcanvasGroup.alpha = 0;
        mcanvasGroup.interactable = false;
        mcanvasGroup.blocksRaycasts = false;
    }
}
