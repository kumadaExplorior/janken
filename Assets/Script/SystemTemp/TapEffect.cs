using DG.Tweening;
using UnityEngine;

public class TapEffect : MonoBehaviour
{

    [SerializeField] Camera _camera;
    // カメラの座標

    [SerializeField] GameObject tf;
    [SerializeField] Transform parentTF;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // マウスのワールド座標までパーティクルを移動し、パーティクルエフェクトを1つ生成する
            var pos = _camera.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward * 10);
            pos = new Vector3(pos.x,pos.y,-1000);

            var newGO = Instantiate(tf, parentTF);
            newGO.transform.localPosition = pos;
            newGO.SetActive(true);
            DOVirtual.DelayedCall(3f, () =>
            {
                Destroy(newGO);
            });
        }
    }
}