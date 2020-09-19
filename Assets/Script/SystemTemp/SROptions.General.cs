using UnityEngine;
using System;
using System.ComponentModel;
using TW.GameSetting;

/// <summary>
/// 全般のデバッグ機能
/// </summary>
public partial class SROptions: SystemBaseManager
{
    #region 定数

    /// <summary>
    /// 全般カテゴリ
    /// </summary>
    private const string GeneralCategory = "General";

    #endregion


    #region デバッグ機能

    [Category(GeneralCategory)]
    [DisplayName("TimeScale")]
    [Sort(0)]
    [Increment(0.1)]
    [NumberRange(0.0, 10.0)]
    public float TimeScale
    {
        get { return Time.timeScale; }
        set { Time.timeScale = value; }
    }

    [Category(GeneralCategory)]
    [DisplayName("DisplayDateTime")]
    [Sort(1)]
    public void DisplayDateTime()
    {
        Debug.Log(DateTime.Now.ToString("yyyy/MM/dd"));
    }

    [Category(GeneralCategory)]
    [DisplayName("LightEnabled")]
    [Sort(2)]
    public bool LightEnabled
    {
        get { return GameObject.FindObjectOfType<Light>().enabled; }
        set { GameObject.FindObjectOfType<Light>().enabled = value; }
    }

    [Category(GeneralCategory)]
    [DisplayName("TransitionTitle")]
    [Sort(3)]
    public void TransitionTitle()
    {
        ChangeScene(SceneType.Title);
    }

    [Category(GeneralCategory)]
    [DisplayName("TransitionHome")]
    [Sort(4)]
    public void TransitionHome()
    {
        ChangeScene(SceneType.Home);
    }

    [Category(GeneralCategory)]
    [DisplayName("TransitionCharaDebug")]
    [Sort(5)]
    public void TransitionCharaDebug()
    {
        ChangeScene(SceneType.CharaDebug);
    }

    #endregion
}