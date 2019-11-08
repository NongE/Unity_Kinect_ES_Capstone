using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UGUI에 접근하려면 추가

public class HPManager : MonoBehaviour
{
    public static float hitFlag = 0;
    public Slider hpBar;
   
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (hitFlag > 0)
        {
            hpBar.value -=0.5f;
            hitFlag -= 0.5f;
        }
    }
}
