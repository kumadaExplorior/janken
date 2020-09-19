using System;
using System.Collections;
using System.Collections.Generic;
using PW;
using TW.GameSetting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TWManger : NLSingletonDontDestroyObject<TWManger>
{
    [SerializeField] public Transform _dialogRoot;
    [SerializeField] public Transform characterRoot;
    [SerializeField] Camera _dialogCamera;
    [SerializeField] public Canvas tapCanvas;
    [NonSerialized] protected static PlayType playType = PlayType.Moving;
    [NonSerialized] public ColEventType onTriCharaType;
    [NonSerialized] public SystemBaseManager systemBaseManager;

    public static PlayType PLAYTYPE
    {
        get { return playType; }
    }

    private Dictionary<string, object> data_hash;
    public Dictionary<string, object> Data_hash
    {
        get { return data_hash; }
    }

    public void Start()
    {
        Observe();
        var sceneType = (SceneType)Enum.Parse(typeof(SceneType), SceneManager.GetActiveScene().name);
        ChangeScene(sceneType, null);
    }



    public void Observe()
    {
        //Debug.Log("Observe");

        //this.ObserveEveryValueChanged(x=>this.moveController)
        //    .Where(x => true)
        //    .Subscribe(_ =>
        //    {
        //        if(moveController!=null)
        //        {
        //            Debug.Log("moveController 入ったぁ");
        //        }
        //    });

    }

    public void Initialized()
    {
        //コントローラをセットする
        ControllerChange(playType);

        //if (moveController != null)
        //{
        //    moveController.enabled = true;
        //    //moveController.Initialized();
        //}

        //if (uIController != null)
        //{
        //    uIController.enabled = false;
        //}
    }


    public void ChangeScene(SceneType sceneType, Dictionary<string, object> hash)
    {
        SetPlayType(sceneType);

        data_hash = hash;

    }


    public void SetPlayType(SceneType sceneType)
    {
        //Move,UIControllerは設定されてるものとして処理される
        Debug.Log("SetPlayType:" + sceneType);

        switch (sceneType)
        {
            case SceneType.Battle:
                playType = PlayType.Battle;
                StartCoroutine(SetControllerCallBack(() => { systemBaseManager.Init(); }));
                break;

            case SceneType.Home:
            case SceneType.CharaDebug:
                playType = PlayType.Moving;
                StartCoroutine(SetControllerCallBack(() => { systemBaseManager.Init(); }));
                break;
            default:
                Debug.LogWarning("Not Need SetPlayType");
                break;
        }

    
    }

    public void ControllerChange(PlayType playType)
    {

        //Debug.Log(uIController + " :ControllerChange:" + playType);

        //switch (playType)
        //{
        //    case PlayType.Menu:
        //        moveController.StopAllCoroutines();
        //        moveController.enabled = false;
        //        uIController.enabled = true;
        //        cinemachineBrain.enabled = false;
        //        break;
        //    case PlayType.Moving:
        //    case PlayType.Battle:
        //        uIController.StopAllCoroutines();
        //        uIController.Initialized(playType);
        //        uIController.enabled = false;
        //        moveController.enabled = true;
        //        moveController.Initialized();
        //        cinemachineBrain.enabled = true;
        //        break;
        //    default:
        //        Debug.LogError("ControllerChange is error playType:" + playType);
        //        break;
        //}
    }


    private IEnumerator SetControllerCallBack(Action callBack)
    {
        while (true)
        {
            yield return null;

            //if (uIController != null && moveController != null && systemBaseManager != null)
            //{
            //    Debug.Log("=======Controller Set完了");
            //    Initialized();
            //    callBack();
            //    break;
            //}
        }
    }


}
