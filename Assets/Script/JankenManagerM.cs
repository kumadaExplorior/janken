using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JankenManagerM : MonoBehaviour
{
    //ジャンケン画像
    [SerializeField] Image image;
    //敵画像
    [SerializeField] Image souri;

    //勝った数テキスト
    [SerializeField] TextMeshProUGUI winCountText;

    //プレイヤーが出したジャンケン
    int PlayerJanken = 0;
    //CPUが出したジャンケン
    int cpuJanken = 0;

    //処理待ちフラグ
    bool stopFlg = false;

    //勝った数
    int winCount = 0;
    //負けた数
    int loseCount = 0;


    //起動時一回しか通らない
    private void Start()
    {
        winCountText.text = winCount.ToString();

        Initialized();
    }

    //初期化　
    public void Initialized()
    {
        stopFlg = false;

        //相手のジャンケンは非表示
        image.gameObject.SetActive(false);

        //敵初期画像
        souri.sprite = Resources.Load<Sprite>("Souri1");
    }

    //敵のアニメーション
    public IEnumerator EnemyAction()
    {
        if(stopFlg == true)
        {
            yield break;
        }

        stopFlg = true;

        yield return new WaitForSeconds(1f);

        //相手のジャンケン出目
        cpuJanken = Random.RandomRange(1, 4);

        //敵出目表示
        image.gameObject.SetActive(true);
        image.sprite = Resources.Load<Sprite>(cpuJanken.ToString());

        //敵画像変更
        souri.sprite = Resources.Load<Sprite>("Souri2");

        //ジャンケン判定
        CpuAction();

        winCountText.text = winCount.ToString();

        //3秒後にもとに戻す
        yield return new WaitForSeconds(3f);
        Initialized();
    }


    public void ButtonOshita()
	{
		Debug.Log("押したよ");
	}
    public void GuuButton()
    {
    	Debug.Log("グー");
        PlayerJanken = 1;
        StartCoroutine(EnemyAction());
    }
    public void CyokiButton()
    {
    	Debug.Log("チョキ");
    	PlayerJanken = 2;
        StartCoroutine(EnemyAction());
    }  
    public void ParButton()
    {
        Debug.Log("パー");
    	PlayerJanken = 3;
        StartCoroutine(EnemyAction());
    }

    public void CpuAction()
    {
        if (cpuJanken == 1) 
        {
            Debug.Log("cpuJanken" + "グー");
        }
        else if(cpuJanken == 2)   
        {
            Debug.Log("cpuJanken" + "チョキ");
        }
        else if(cpuJanken == 3)
        {
            Debug.Log("cpuJanken" + "パー");
        }
        judge();
    }
    public void judge()
    {       
        if (PlayerJanken == cpuJanken)
        {
            Debug.Log("あいこ");
        }
        else if(PlayerJanken == 1)
        {
            if(cpuJanken == 2)
            {
                Win();
            }
            else
            {
                Lose();
            }
        }
        else if(PlayerJanken == 2)
        {
            if(cpuJanken == 1)
            {
                Lose();
            }
            else{
                Win();

            }
        }
        else if(PlayerJanken == 3)
        {
            if(cpuJanken == 1)
            {
                Win();
            }
            else
            {
                Lose();
            }
        }

    }

    public void Win()
    {
        winCount++;
        Debug.Log("勝ち:" + winCount);
    }

    public void Lose()
    {
        loseCount++;
        Debug.Log("負け:" + loseCount);
       
    }


}
