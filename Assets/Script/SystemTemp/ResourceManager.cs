using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PW;
using System;
using TW.GameSetting;

public class ResourceManager : NLSingletonDontDestroyObject<ResourceManager>
{
    [SerializeField] private static bool isLocal = true;

    public GameObject GetCharaModel(CharaType charaType, int id)
    {
        GameObject go = null;

        if (isLocal)
            go = Resources.Load<GameObject>("Prefab/" + charaType.ToString() + "/" +id);


        if(go==null)
        {
            Debug.LogError("データを取得できません。");
        }

        return go;
    }
    

    public void SetEffect(EffectType effectType, Transform parentTF)
    {
        //GameObject ef = null;
        //var effectMaster = DataManager.Instance.GetEffectMasterData(effectType);

        //if (isLocal)
        //    ef = Resources.Load<GameObject>("Effects/" + effectType.ToString());

        //if (effectMaster.effrctRangeType == 2)
        //{
        //    Vector3 vector3 = parentTF.position;
        //    parentTF = Instantiate(parentTF.gameObject, null).transform;
        //    parentTF.localPosition = vector3;
        //    Destroy(parentTF.gameObject, GameSettingData.EffectDestroySecond + 1);
        //}

        //if (ef != null)
        //    Destroy(Instantiate(ef, parentTF), GameSettingData.EffectDestroySecond);

    }
    public void SetEffect(int effectID, Transform parentTF)
    {
        SetEffect((EffectType)Enum.ToObject(typeof(EffectType), effectID), parentTF);
    }


    public Sprite GetCardImage(int id)
    {
        return Resources.Load<Sprite>("Image/Card/" + id);
    }

}
