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

    [SerializeField] TextMeshProUGUI HanteiText;

    [SerializeField] List<GameObject> buttons;

    //highscore

    [SerializeField] TextMeshProUGUI highScore;

    //プレイヤーが出したジャンケン
    int PlayerJanken = 0;
    //CPUが出したジャンケン
    int cpuJanken = 0;

    //処理待ちフラグ
    bool stopFlg = false;
    bool winFlg = false;

    //勝った数
    int winCount = 0;
    //負けた数
    int loseCount = 0;
    
    //判定
    int Hantei = 0;


    //起動時一回しか通らない
    private void Start()
    {
        winCountText.text = winCount.ToString();
        HanteiText.text = "";

        Initialized();
    }

    //初期化　
    public void Initialized()
    {
        stopFlg = false;

        foreach(var button in buttons)
        {
            button.SetActive(true);
        }

        //伏せるアクション
        EnbemyCloseAction();
    }

    //敵が伏せるアクション
    public void EnbemyCloseAction()
    {
        //相手のジャンケンは非表示
        image.gameObject.SetActive(false);
        //相手の身分テキストは非表示
        HanteiText.gameObject.SetActive(false);
        //敵初期画像
        souri.sprite = Resources.Load<Sprite>("Souri1");
    }

    //敵のアニメーション
    public IEnumerator EnemyAction()
    {
        if (stopFlg == true)
        {
            yield break;
        }

        stopFlg = true;

        //敵ジャンケン処理
        yield return new WaitForSeconds(1f);
        CpuAction();
      
        //伏せる
        yield return new WaitForSeconds(2f);
        EnbemyCloseAction();

        //身分判定　上げて表示
        yield return new WaitForSeconds(1f);
        Mibun();

        //初期化
        yield return new WaitForSeconds(2f);
        Initialized();

    }


    public void ButtonOshita()
    {
        Debug.Log("押したよ");
    }
    public void GuuButton()
    {   Debug.Log("グー");
        PlayerJanken = 1;
        UnitAction();
    }
    public void CyokiButton()
    {
        Debug.Log("チョキ");
        PlayerJanken = 2;
        UnitAction();
    }
    public void ParButton()
    {
        Debug.Log("パー");
        PlayerJanken = 3;
        UnitAction();
    }

    public void UnitAction()
    {
        PlayerAction();
        StartCoroutine(EnemyAction());
    }

    public void PlayerAction()
    {
        foreach(var button in buttons)
        {
            if(button.GetComponent<JankenData>().id != PlayerJanken)
            {
                button.SetActive(false);
            }
        }
    }

    //敵のジャンケンアクション
    public void CpuAction()
    {
        //相手のジャンケン出目
        cpuJanken = Random.RandomRange(1, 4);

        //敵画像変更 上げる
        souri.sprite = Resources.Load<Sprite>("Souri2");

        //敵出目表示
        image.gameObject.SetActive(true);
        image.sprite = Resources.Load<Sprite>(cpuJanken.ToString());

        if (cpuJanken == 1)
        {
            Debug.Log("cpuJanken" + "グー");
        }
        else if (cpuJanken == 2)
        {
            Debug.Log("cpuJanken" + "チョキ");
        }
        else if (cpuJanken == 3)
        {
            Debug.Log("cpuJanken" + "パー");
        }

        //勝敗判定
        Judge();
    }

    //勝敗判定
    public void Judge()
    {
        if (PlayerJanken == cpuJanken)
        {
            Debug.Log("あいこ");
        }
        else if (PlayerJanken == 1)
        {
            if (cpuJanken == 2)
            {
                Win();
            }
            else
            {
                Lose();
            }
        }
        else if (PlayerJanken == 2)
        {
            if (cpuJanken == 1)
            {
                Lose();
            }
            else
            {
                Win();

            }
        }
        else if (PlayerJanken == 3)
        {
            if (cpuJanken == 1)
            {
                Win();
            }
            else
            {
                Lose();
            }
        }


    }

    //勝った処理
    public void Win()
    {
        winCount++;
        //テキスト更新
        winCountText.text = winCount.ToString();
        Debug.Log("勝ち:" + winCount);

        winFlg = true;
        Rensyou();
    }

    //負けた処理
    public void Lose()
    {
        loseCount++;
        Debug.Log("負け:" + loseCount);

        winFlg = false;
        Rensyou();

    }

    public void Rensyou()
    {
        if (winFlg = true)
        {
            highScore.text = PlayerPrefs.GetInt("SCORE", 0).ToString();
            highScore++;
            PlayerPrefs.GetInt("SCORE", highScore);
            Debug.Log(PlayerPrefs.GetInt("SCORE", 0));
        }
        else
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.DeleteKey("SCORE");
        }


    }

    public void Mibun()
    {
        //敵画像変更　額上げる
        souri.sprite = Resources.Load<Sprite>("Souri2");
        //判定テキスト表示
        HanteiText.gameObject.SetActive(true);

        //1回負けたら平民
        if (winCount - loseCount == -1)
        {
            HanteiText.text = "平\n民";
            Debug.Log("平民");
        }
        else if (winCount - loseCount == -2)
        {
            HanteiText.text = "貧\n民";
            Debug.Log("貧民");
        }
        else if (winCount - loseCount == -3)
        {
            HanteiText.text = "大\n貧\n民";
            Debug.Log("大貧民");
        }
        else if (winCount - loseCount == 1)
        {
            HanteiText.text = "富\n豪";
            Debug.Log("富豪");
        }
        else if (PlayerJanken == cpuJanken)
        {
            Initialized();
        }
        else
        {
            HanteiText.text = "作\n成\n中";
        }
    }
　　
   
}
