using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UGUI에 접근하려면 추가
using UnityEngine.SceneManagement;

public class ManualProgressBar : MonoBehaviour
{
    public Slider progressBar;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Stage1BackgroundRepeat.audioSource.time != 0)
        {
            progressBar.value = Stage1BackgroundRepeat.audioSource.time;

        }


    }


}
