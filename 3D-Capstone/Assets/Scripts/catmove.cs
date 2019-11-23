using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class catmove : MonoBehaviour
{
    float time;
    float catX = -8f;
    float catY = -2.5f;
    float catZ = -4f;

    float bgX = 0f;
    float bgY = -11f;
    float bgZ = 0f;

    int catFlag = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (bgY < 0)
        {
            time += Time.deltaTime; // 시간 시작
            if (time > 1.5f)
            {
                GameObject.Find("BackgroundRepeat").gameObject.transform.position = new Vector3(bgX, bgY, bgZ); // 중앙
                bgY += 0.03f;
            }

        }
        else
        {
            if (catFlag == 0)
            {
                time = 0;
                catFlag = 1;
                //ManualBackgroundRepeat.setScrollSpeed(0.1f);
                
            }
            time += Time.deltaTime; // 시간 시작
            bgY = 0;
            if (time > 1.0f)
            {
                BackgroundRepeat.scrollSpeed = 0.05f;
                //GameObject.Find("ManualBackgound").gameObject.transform.position = new Vector3(bgX, bgY, bgZ); // 중앙
                GameObject.Find("Canvas").transform.Find("Cat").gameObject.transform.position = new Vector3(catX, catY, catZ); // 중앙
                catX += 0.03f;
            }



            if(catX > 7) // 메뉴얼 완료
            {
                GameObject.Find("Canvas").transform.Find("ManualLogoFadeOut").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("ManualLogoFadeOut").SendMessage("StartFadeAnim");
                //GameObject.Find("ManualLogoFadeOut").SendMessage("StartFadeAnim");
                Invoke("clicked", 2f);
                
            }

        }
    

    }
    // tempZ -= 0.015f;
    private void clicked()
    {
        SceneManager.LoadScene("IntroScene");
    }
    
}
