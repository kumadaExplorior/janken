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

    [SerializeField] TextMeshProUGUI loseCountText;

    [SerializeField] TextMeshProUGUI highScoreCountText;

    [SerializeField] TextMeshProUGUI HanteiText;

    [SerializeField] TextMeshProUGUI SouriText;

    [SerializeField] List<GameObject> buttons;



    //highscore

    [SerializeField] TextMeshProUGUI highScore;

    //プレイヤーが出したジャンケン
    int PlayerJanken = 0;
    //CPUが出したジャンケン
    int cpuJanken = 0;

    //処理待ちフラグ
    bool stopFlg = false;

    //勝った数
    int winCount = 0;
    int consecutiveCount = 0;
    //負けた数
    int loseCount = 0;
    
    //判定
    int Hantei = 0;

    //起動時一回しか通らない
    private void Start()
    {

        winCountText.text = winCount.ToString();
        HanteiText.text = "";
        highScore.text = PlayerPrefs.GetInt("SCORE", 0).ToString();
        Initialized();
    }

    //初期化　
    public void Initialized()
    {
        SouriText.gameObject.SetActive(false);

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
        bool isWin = CpuAction();
      
        //伏せる
        yield return new WaitForSeconds(2f);
        EnbemyCloseAction();

        //身分判定　上げて表示
        yield return new WaitForSeconds(1f);
        Mibun();
        CommentSet(isWin);

        //初期化
        yield return new WaitForSeconds(2f);
        Initialized();

    }


    public void ButtonOshita()
    {
        Debug.Log("押したよ");
    }
    public void GuuButton()
    {
        PlayerJanken = 1;
        UnitAction();
    }
    public void CyokiButton()
    {
        PlayerJanken = 2;
        UnitAction();
    }
    public void ParButton()
    {
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
    public bool CpuAction()
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
            //Debug.Log("cpuJanken" + "パー");
        }

        //勝敗判定
        return Judge();
    }

    //勝敗判定
    public bool Judge()
    {
        if (PlayerJanken == cpuJanken)
        {
            Debug.Log("あいこ");
            return false;
        }
        else if (PlayerJanken == 1)
        {
            if (cpuJanken == 2)
            {
                return Win();
            }
            else
            {
                return Lose();
            }
        }
        else if (PlayerJanken == 2)
        {
            if (cpuJanken == 1)
            {
                return Lose();
            }
            else
            {
                return Win();

            }
        }
        else if (PlayerJanken == 3)
        {
            if (cpuJanken == 1)
            {
                return Win();
            }
            else
            {
                return Lose();
            }
        }

        return false;

    }

    //勝った処理
    public bool Win()
    {
        winCount++;
        consecutiveCount++;
        //テキスト更新
        winCountText.text = winCount.ToString();
        Debug.Log("勝ち:" + winCount);
        Rensyou();

        return true;
    }

    //負けた処理
    public bool Lose()
    {
        loseCount++;
        consecutiveCount = 0;//連勝記録は０に

        loseCountText.text = loseCount.ToString();

        Debug.Log("負け:" + loseCount);
        Rensyou();

        return false;

    }

    public void Aiko()
    {
        consecutiveCount = 0;//連勝記録は０に
    }

    public void Rensyou()
    {
        //今までのハイスコア取得
        int highScoreCount = PlayerPrefs.GetInt("SCORE", 0);

        //ハイスコアかどうか
        bool isRensyou = consecutiveCount > highScoreCount;

        Debug.Log("consecutiveCount:" + consecutiveCount + "  highScoreCount:"+ highScoreCount);

        if (isRensyou == true)
        {
            highScore.text = PlayerPrefs.GetInt("SCORE", 0).ToString();
            PlayerPrefs.GetInt("SCORE", consecutiveCount);
            Debug.Log(PlayerPrefs.GetInt("SCORE", 0));

            //テキスト設定
            highScore.text = consecutiveCount.ToString();
            Debug.Log("連勝記録セット");
            //新たにハイスコア設定
            PlayerPrefs.SetInt("SCORE", highScoreCount + 1);
        }

    }

    public void Mibun()
    {
        //敵画像変更　額上げる
        souri.sprite = Resources.Load<Sprite>("Souri2");
        //判定テキスト表示
        HanteiText.gameObject.SetActive(true);

        //1回負けたら平民
        if (winCount - loseCount == 0)
        {
            HanteiText.text = "平\n民";
            Debug.Log("平民");
        }
        else if (winCount - loseCount == -1)
        {
            HanteiText.text = "貧\n民";
            Debug.Log("貧民");
        }
        else if (winCount - loseCount == -2)
        {
            HanteiText.text = "大\n貧\n民";
            Debug.Log("大貧民");
        }

        else if (winCount - loseCount == 1)
        {

            HanteiText.text = "富\n豪";
            Debug.Log("富豪");
        }
        else if (winCount - loseCount == 2)
        {
            HanteiText.text = "大\n富\n豪";
            Debug.Log("大富豪");
        }
        else if (winCount - loseCount == 3)
        {

            HanteiText.text = "し\nゅ\nご\nい";
            Debug.Log("総理");
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


    public void CommentSet(bool iswin)
    {
        SouriText.gameObject.SetActive(true);

        if(winCount == 20)
        {
            Reset();
            SouriText.text = "記憶が。。。";
        }
        else if(consecutiveCount == 3)
        {
            SouriText.text = "君がそうだ";
        }else if(winCount == 10)
        {
            SouriText.text = "なんか";
        }
        else if (iswin)
        {
            SouriText.text = "やるな";
        }else
        {
            SouriText.text = "よわ";
        }

    }

    public void Reset()
    {
        //初期値に戻す
        winCount = 0;
        loseCount = 0;
    }
}
