using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Testdayo : MonoBehaviour
{
   [SerializeField] Image image;

    private void Start()
    {
        string imageName = Random.RandomRange(1,4).ToString();

        image.sprite = Resources.Load<Sprite>(imageName);
        
    }
}
