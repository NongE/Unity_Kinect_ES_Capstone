using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UGUI에 접근하려면 추가
using UnityEngine.SceneManagement;

public class Stage2HPManager : MonoBehaviour
{
    public static float hitFlag = 0;
    public Slider hpBar;
    public static AudioSource audioSource; // 게임오버

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (hitFlag > 0)
        {
            hpBar.value -=0.5f;
            hitFlag -= 0.5f;
            if (hpBar.value <= 0)
            {
                Stage2BackgroundRepeat.audioSource.Stop();
                GameObject.Find("Fade Out").SendMessage("StartFadeAnim");
                audioSource.Play();
                Invoke("gameOver", 2f);
            }
        }
    }

    void gameOver()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
