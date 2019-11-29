using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroBackground : MonoBehaviour
{

    Vector3 pos;
    GameObject logo;


    public float scrollSpeed;
    //스크롤할 속도를 로 지정해 줍니다.
    private Material thisMaterial;
    //Quad의 Material 데이터를 받아올 객체를 선언합니다.

    //float time;

    public float animTime = 1f;         // Fade 애니메이션 재생 시간 (단위:초). 
    private float start = 1f;           // Mathf.Lerp 메소드의 첫번째 값.  
    private float end = 0f;             // Mathf.Lerp 메소드의 두번째 값.  
    private float time = 0f;            // Mathf.Lerp 메소드의 시간 값.  

    private bool isPlaying = false;     // Fade 애니메이션의 중복 재생을 방지하기위해서 사용. 
    private int fadeFlag = 0;
    public GameObject gameLogo;


    private int logoMoveFlag = 0;


    private float logoTime = 0f;            // Mathf.Lerp 메소드의 시간 값.  

    public void StartFadeIn()
    {
        // 애니메이션이 재생중이면 중복 재생되지 않도록 리턴 처리.  
        if (isPlaying == true)
            return;

        // Fade 애니메이션 재생.  
        StartCoroutine("PlayFadeIn");
    }

    // Fade 애니메이션 메소드.  
    IEnumerator PlayFadeIn()
    {
        // 애니메이션 재생중.  
        isPlaying = true;

        // Image 컴포넌트의 색상 값 읽어오기.  
        Color color = gameLogo.GetComponent<RawImage>().color;

        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
            // 경과 시간 계산.  
            // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
            time += Time.deltaTime / animTime;

            // 알파 값 계산.  
            color.a = Mathf.Lerp(start, end, time);
            // 계산한 알파 값 다시 설정.  

            gameLogo.GetComponent<RawImage>().color = color;

            yield return null;
        }

        // 애니메이션 재생 완료.  
        isPlaying = false;
        fadeFlag = 1;
    }


    public void StartFadeOut()
    {
        // 애니메이션이 재생중이면 중복 재생되지 않도록 리턴 처리.  
        if (isPlaying == true)
            return;

        // Fade 애니메이션 재생.  
        StartCoroutine("PlayFadeOut");
    }

    // Fade 애니메이션 메소드.  
    IEnumerator PlayFadeOut()
    {
        // 애니메이션 재생중.  
        isPlaying = true;

        // Image 컴포넌트의 색상 값 읽어오기.  
        Color color = gameLogo.GetComponent<RawImage>().color;

        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < 1f)
        {
            // 경과 시간 계산.  
            // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
            time += Time.deltaTime / animTime;

            // 알파 값 계산.  
            color.a = Mathf.Lerp(start, end, time);
            // 계산한 알파 값 다시 설정.  

            gameLogo.GetComponent<RawImage>().color = color;

            yield return null;
        }

        // 애니메이션 재생 완료.  
        isPlaying = false;
        fadeFlag = 0;
    }






    void Start()
    {
        GameObject.Find("LogoFadeIn").SendMessage("StartFadeAnim");
        //객체가 생성될때 최초 1회만 호출 되는 함수 입니다.
        thisMaterial = GetComponent<Renderer>().material;
        //현재 객체의 Component들을 참조해 Renderer라는 컴포넌트의 Material정보를 받아옵니다.


    }

    void Update()
    {

        // time += Time.deltaTime; // 시간 시작
        Debug.Log(logoTime);
        if (logoMoveFlag == 0)
        {
            pos = GameObject.Find("GameLogo").transform.position;

            if (pos.y > 690)
            {
                pos.y -= 10;
            }
            else
            {
                logoMoveFlag = 1;

            }
        }

        if (logoMoveFlag == 1)
        {
            logoTime += Time.deltaTime;
        }


        if (logoTime >= 2.0f)
        {

            if (fadeFlag == 1)
            {

                start = 0f;
                end = 1f;
                StartFadeOut();
            }
            else if (fadeFlag == 0)
            {

                start = 1f;
                end = 0f;
                StartFadeIn();
            }
        }


        GameObject.Find("Canvas").transform.Find("GameLogo").gameObject.transform.position = pos;

        Vector2 newOffset = thisMaterial.mainTextureOffset;
        // 새롭게 지정해줄 OffSet 객체를 선언합니다.
        newOffset.Set(newOffset.x + (scrollSpeed * Time.deltaTime), 0);
        // Y부분에 현재 y값에 속도에 프레임 보정을 해서 더해줍니다.
        thisMaterial.mainTextureOffset = newOffset;
        //그리고 최종적으로 Offset값을 지정해줍니다.
    }
}