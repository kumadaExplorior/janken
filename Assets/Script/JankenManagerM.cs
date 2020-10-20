using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankenManagerM : MonoBehaviour
{
    int PlayerJanken = 0;
    int cpuJanken = 0;

	public void ButtonOshita()
	{
		Debug.Log("押したよ");
	}
    public void GuuButton()
    {
    	Debug.Log("グー");
    	PlayerJanken = 1;
        CpuAction();
    }
    public void CyokiButton()
    {
    	Debug.Log("チョキ");
    	PlayerJanken = 2;
        CpuAction();   
    }  
    public void ParButton()
    {
    	Debug.Log("パー");
    	PlayerJanken = 3;
        CpuAction();
    }
    public void CpuAction()
    {
        cpuJanken = Random.RandomRange(1,4);
        
        if(cpuJanken == 1) 
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
        if(PlayerJanken == cpuJanken)
        {
            Debug.Log("あいこ");
        }
        else if(PlayerJanken == 1)
        {
            if(cpuJanken == 2)
            {
                Debug.Log("勝ち");
            }
            else
            {
                Debug.Log("負け");
            }
        }
        else if(PlayerJanken == 2)
        {
            if(cpuJanken == 1)
            {
                Debug.Log("負け");
            }
            else{
                Debug.Log("勝ち");
            }
        }
        else if(PlayerJanken == 3)
        {
            if(cpuJanken == 1)
            {
                Debug.Log("勝ち");
            }
            else
            {
                Debug.Log("負け");
            }
        }

    }


}
