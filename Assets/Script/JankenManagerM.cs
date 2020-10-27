using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JankenManagerM : MonoBehaviour
{
    [SerializeField] Image image;

    int PlayerJanken = 0;
    int cpuJanken = 0;

    public IEnumerator Test()
    {

        yield return new WaitForSeconds(3f);

        image.sprite = Resources.Load<Sprite>(Random.RandomRange(1,4).ToString());

        yield return new WaitForSeconds(2f);

        image.sprite = Resources.Load<Sprite>("Souri1");

        yield return new WaitForSeconds(3f);

        image.sprite = Resources.Load<Sprite>("Souri2");

    }


    public void ButtonOshita()
	{
		Debug.Log("押したよ");
	}
    public void GuuButton()
    {
    	Debug.Log("グー");
        //PlayerJanken = 1;
        //   CpuAction();
        StartCoroutine(Test());
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
        image.sprite = Resources.Load<Sprite>(Random.RandomRange(1, 4).ToString());

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
