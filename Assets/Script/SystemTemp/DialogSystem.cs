using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Explorior;
using System;
using TW.GameSetting;

public class DialogSystem : SystemBaseManager
{
    [SerializeField] Transform contents;

    public void DialogSystemInitialize()
    {
        gameObject.SetActive(true);
        Open();
    }

    public void Open(Action callBack = null)
    {
        UI.FadeAction(isIn:true, GetComponent<CanvasGroup>(), duration: GameSettingData.DIALOG_EFFECT_TIME);
        UI.UIsclaleAction(isUp: true, contents, duration: GameSettingData.DIALOG_EFFECT_TIME, callBack:callBack);
    }

    public void Close()
    {
        UI.FadeAction(isIn: false, GetComponent<CanvasGroup>(), duration: GameSettingData.DIALOG_EFFECT_TIME);
        UI.UIsclaleAction(isUp: false, contents, duration: GameSettingData.DIALOG_EFFECT_TIME, ()=> { gameObject.SetActive(false); });
    }
}
