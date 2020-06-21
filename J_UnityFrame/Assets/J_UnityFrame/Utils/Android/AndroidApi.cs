using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static  class AndroidApi
{

    /// <summary>
    /// 获取路径
    /// </summary>
    /// <returns></returns>
    public static string GetPath()
    {
        string path;
#if UNITY_EDITOR||UNITY_STANDALONE_WIN
        //Editor
        path = "file://" + Application.dataPath + "/StreamingAssets/";
        //Application.dataPath;        
#elif UNITY_ANDROID
        //Android
        path = "jar:file://" + Application.dataPath + "!/assets/";
        //Application.persistentDataPath

#else
        //IPhone
#endif
        return path;
    }

    /// <summary>
    /// 手机震动
    /// </summary>
    /// 调用一次震动0.5s
    public static void Shake()
    {
#if UNITY_EIDOTR

#elif UNITY_ANDROID
        Handheld.Vibrate();
#elif UNITY_IPHONE
        iPhoneUtils.Vibrate()
#endif
    }

    public static void Shake(float time)
    {
        //需要调用android接口
    }

    /// <summary>
    /// 调安卓原生信息弹窗
    /// </summary>
    /// <param name="info"></param>
    public static void MakeToast(string info)
    {


#if UNITY_EDITOR

#elif UNITY_ANDROID
      try
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
            currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
                Toast.CallStatic<AndroidJavaObject>("makeText", currentActivity, info, Toast.GetStatic<int>("LENGTH_LONG")).Call("show");
            }));

            /*
            // 匿名方法中第二个参数是安卓上下文对象，除了用currentActivity，还可用安卓中的GetApplicationContext()获得上下文。
            AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
            */
        }
        catch (System.Exception)
        {
          
        }
#endif
    }


    public static string DeviceModel
    {
        get
        {
            return SystemInfo.deviceModel;
        }
    }

    public static string DeviceName
    {
        get
        {
            return SystemInfo.deviceName;
        }
    }

    public static string DiviceType
    {
        get
        {
            string typeName = null;
            var mType = SystemInfo.deviceType;
            switch (mType)
            {
                case DeviceType.Unknown:
                    typeName = "Unknown";
                    break;
                case DeviceType.Handheld:
                    typeName = "A handheld device like mobile phone or a tablet";
                    break;
                case DeviceType.Console:
                    typeName = "A stationary gaming console";
                    break;
                case DeviceType.Desktop:
                    typeName = "Desktop or laptop computer";
                    break;
                default:
                    break;
            }
            return typeName;
        }
    }

    public static string IMEI
    {
        get
        {
            return SystemInfo.deviceUniqueIdentifier;
        }
    }
    /// <summary>
    /// 操作系统
    /// </summary>
    public static string OperatingSystem
    {
        get
        {           
            return SystemInfo.operatingSystem;
        }
    }


    /// <summary>
    /// 复制
    /// </summary>
    /// <param name="mstr"></param>
    public static void AsCopyString(this string mstr)
    {
        GUIUtility.systemCopyBuffer = mstr;        
    }

    /// <summary>
    /// 粘贴
    /// </summary>
    public static string GetCopyString
    {
        get
        {
            return GUIUtility.systemCopyBuffer;
        }       
    }
}
