using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JanekenManger : MonoBehaviour
{
    //1 : グー
    //2 : チョキ
    //3 : パー

    int playerJanken = 0;
    int cpuJanken = 0;

    public void ButtonOshita()
    {       
        Debug.Log("押したよ");
    }

    public void GooButton()
    {
        Debug.Log("グー");
        playerJanken = 1;
        CPUAction();
    }

    public void ChokiButton()
    {
        Debug.Log("チョキ");
        playerJanken = 2;
        CPUAction();
    }

    public void ParButton()
    {
        Debug.Log("パー");
        playerJanken = 3;
        CPUAction();
    }
    public void CPUAction()
    { 
        Debug.Log("cpuJanken:" + cpuJanken);
        Jurge();
    }


    public void Jurge()
    {
        if(playerJanken == cpuJanken)
        {
            Debug.Log("あいこ");
        }else if(playerJanken == 1)
        {
            if(cpuJanken == 2)
            {
                Debug.Log("プレイヤー勝ち");
            }else
            {
                Debug.Log("プレイヤー負け");
            }     
        }
        else if(playerJanken == 2)
        {
            if (cpuJanken == 3)
            {
                Debug.Log("プレイヤー勝ち");
            }
            else
            {
                Debug.Log("プレイヤー負け");
            }
        }else if(playerJanken == 3)
        {
            if(cpuJanken == 1)
            {
                Debug.Log("プレイヤー勝ち");
            }
            else
            {
                Debug.Log("プレイヤー負け");
            }
        }

    }
}
