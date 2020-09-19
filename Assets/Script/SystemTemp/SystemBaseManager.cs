using System;
using System.Collections.Generic;
using Explorior;
using Prime31.TransitionKit;
using TW.GameSetting;
using UnityEngine;

public class SystemBaseManager : MonoBehaviour
{
    private static bool isDebug = true;
    private static Dictionary<string, object> _data_hash;

    private bool systemInit;

    public Dictionary<string, object> Data_hash
    {
        get { return _data_hash; }
    }

    public virtual void Init()
    {
        Debug.Log("SystemBaseManager Init");
        systemInit = true;
    }

    public void ChangeScene(int _sceneType)
    {
        ChangeScene((SceneType)_sceneType);
    }
    public void ChangeScene(SceneType _sceneType)
    {
        ChangeScene(_sceneType, null);
    }
    public void ChangeScene(SceneType _sceneType, Dictionary<string, object> hash)
    {
        Debug.Log("sceneType:" + _sceneType);
        _data_hash = hash;

        var fader = new FadeTransition()
        {
            sceneType = _sceneType,
            data_hash = _data_hash,
            fadedDelay = 0.2f,
            fadeToColor = Color.black
        };

        TransitionKit.instance.transitionWithDelegate(fader);
    }


    public static void SetDebugLog<T>(T debugLog)
    {
        if (isDebug)
            Debug.Log(debugLog.ToString());
    }


    /// <summary>
    /// キャンバスに対してのタップ位置を取得する
    /// </summary>
    /// <param name="canvas"></param>
    /// <returns></returns>
    public Vector2 GetMousePosition(Canvas canvas)
    {
        Vector2 localpos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), Input.mousePosition, canvas.worldCamera, out localpos);
        return localpos;
    }

}
