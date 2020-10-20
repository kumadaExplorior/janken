using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MichikoText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    	int kumada = 8;
    	int ryoma = 3;

    	int total = kumada + ryoma + Random.RandomRange(3,11);

        Debug.Log("テスト^^;" + total);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
