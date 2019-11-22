using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UGUI에 접근하려면 추가
using UnityEngine.SceneManagement;

public class Stage4ProgressBar: MonoBehaviour
{
    public Slider progressBar;


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = Stage4BackgroundRepeat.audioSource.time;


    }

}
