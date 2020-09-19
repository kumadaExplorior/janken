using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using TW.GameSetting;

namespace Explorior
{
    public static class ExtentionUtility
    {
        public static void DebugExpamd(string value)
        {
            if (GameSettingData.buildType == BuildType.Debug)
                Debug.Log(value);
        }

        public static void DebugErrorExpamd(string value)
        {
            if (GameSettingData.buildType == BuildType.Debug)
                Debug.LogError(value);
        }

        public static void ParentInitialize(GameObject baseObject)
        {
            baseObject.SetActive(false);
            Transform tf = baseObject.transform.parent;
            for (int i = 0; i < tf.childCount; i++)
                if (tf.GetChild(i).gameObject != baseObject)
                    MonoBehaviour.Destroy(tf.GetChild(i).gameObject);
        }

        public static List<GameObject> GetAll(this GameObject obj)
        {
            List<GameObject> allChildren = new List<GameObject>();
            GetChildren(obj, ref allChildren);
            return allChildren;
        }

        public static void ColiderInit(this GameObject obj, bool active)
        {
            var list = GetAll(obj);
            foreach(var Value in list)
            {
                var col = Value.GetComponent<Collider>();
                var col2d = Value.GetComponent<Collider2D>();

                if(col!=null)
                    col.enabled = active;

                if(col2d!=null)
                    col2d.enabled = active;
            }
        }

        public static void GetChildren(GameObject obj, ref List<GameObject> allChildren)
        {
            Transform children = obj.GetComponentInChildren<Transform>();
            //子要素がいなければ終了
            if (children.childCount == 0)
            {
                return;
            }
            foreach (Transform ob in children)
            {
                allChildren.Add(ob.gameObject);
                GetChildren(ob.gameObject, ref allChildren);
            }
        }
    }

    public class UI
    {
        public static Tweener FadeAction(bool isIn, CanvasGroup canvasGroup, float duration, Action callBack = null)
        {
            float from = isIn ? 0f : 1f;
            float to = isIn ? 1f : 0f;

            Debug.Log("FadeAction duration:" + duration);
            canvasGroup.alpha = from;            
            return canvasGroup.DOFade(to, duration).OnComplete(() => { callBack?.Invoke(); });
        }

        public static void UIsclaleAction(bool isUp, Transform TF, float duration, Action callBack = null)
        {
            float from = isUp ? 0f : 1f;
            float to = isUp ? 1f : 0f;

            Debug.Log("UIsclaleAction duration:" + duration);
            TF.localScale = Vector3.one * from;
            TF.DOScale(Vector3.one * to, duration).OnComplete(() =>{ callBack?.Invoke();});

        }

        public void UIcutin(Transform TF, float ajustX, float ajustY, float second = 0.5f)
        {
            Vector3 initPosition = TF.localPosition;

            TF.localPosition = new Vector3(TF.localPosition.x + ajustX, TF.localPosition.y + ajustY, TF.localPosition.z);
            TF.gameObject.SetActive(true);

            TF.DOLocalMove(
                    initPosition,
                    second
            ).OnComplete(() => { });
        }

        public void UIcutOut(Transform TF, float ajustX, float ajustY, float second = 0.5f)
        {
            TF.DOLocalMove(
                    new Vector3(TF.localPosition.x + ajustX, TF.localPosition.y + ajustY, TF.localPosition.z),
                    second//時間  
            ).OnComplete(() => { });
        }


        public void UIjump(Transform TF)
        {
            Vector3 vector3 = TF.localPosition;

            TF.DOLocalJump(
                vector3,
                20,                        // ジャンプする力
                3,                        // 移動終了までにジャンプする回数
                2f                        // アニメーション時間
            ).SetDelay(1).OnComplete(() =>
            {
                UIjump(TF);
            });
        }

        public void UIjumpRoop(Transform TF, float roopTime = 1f)
        {
            UIjump(TF);
            DOVirtual.DelayedCall(roopTime, () =>
            {
                UIjumpRoop(TF, roopTime);
            });
        }

        public static void UIRoateRoop(Transform TF, float roopTime = 1f)
        {
            // 1秒かけて90度まで回転
            TF.DORotate(
                new Vector3(0, TF.localEulerAngles.y + 360f),   // 終了時点のRotation
                1.0f                    // アニメーション時間
            ).OnComplete(() =>
            {
                UIRoateRoop(TF, roopTime);
            }); ;
        }

        public static void UIdirectionAnimation(Transform TF, int type, float amount = 5)
        {
            float side = 0;
            float length = 0;
            switch (type)
            {
                case 0://migi
                    side = -1 * amount;
                    break;
                case 1://hidari
                    side = amount;
                    break;
                case 2://ue
                    length = -1 * amount;
                    break;
                case 3://shita
                    length = amount;
                    break;
            }

            Vector3 vector3 = TF.localPosition;
            Vector3 targetVector3 = new Vector3(vector3.x + side, vector3.y + length, vector3.z);

            TF.DOLocalMove(
                    targetVector3,
                    0.3f//時間            
            ).SetDelay(0).OnComplete(() =>
            {
                TF.DOLocalMove(
                    vector3,
                  0.3f//時間            
                ).OnComplete(() =>
                {
                    UIdirectionAnimation(TF, type, amount);
                });
            });
        }

        public void Shake(Transform TF, int interval = 50)
        {
            var sequence = DOTween.Sequence();
            int amount = interval;

            Vector3 baseVevtor3 = TF.localPosition;
            for (int i = 0; i < 5; i++)
            {
                //円の方程式から、ガクガク感を表現 ( 正しか出ないから、ランダムで負にする)
                float x = UnityEngine.Random.Range(-1 * amount, amount);
                float y = Mathf.Sqrt((amount * amount) - (x * x));

                if (UnityEngine.Random.Range(0, 2) == 0)
                {
                    y = y * (-1);
                }

                sequence.Append(
                    TF.DOLocalMove(
                        new Vector3(TF.localPosition.x + x, TF.localPosition.y + y, TF.localPosition.z),
                        0.02f//時間
                    ).SetEase(Ease.OutCubic)
                );
                int icopy = i;
                sequence.Append(
                    TF.DOLocalMove(
                        baseVevtor3,
                        0.02f//時間
                    ).SetEase(Ease.InCubic).OnComplete(() =>
                    {
                    })
                );
            }
        }
    }
}