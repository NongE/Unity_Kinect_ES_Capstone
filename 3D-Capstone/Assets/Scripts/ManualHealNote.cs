using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManualHealNote : MonoBehaviour
{

    public float countSize;

    public float animTime = 2.0f;         // Fade 애니메이션 재생 시간 (단위:초).  
    private float start = 0f;           // Mathf.Lerp 메소드의 첫번째 값.  
    private float end = 1f;             // Mathf.Lerp 메소드의 두번째 값.  
    private float time = 0f;            // Mathf.Lerp 메소드의 시간 값.  

    private bool isPlaying = false;     // Fade 애니메이션의 중복 재생을 방지하기위해서 사용.  

    public GameObject getCountRing;
    public GameObject getOriginalNote;
    // Start is called before the first frame update
    void Start()
    {
        StartFadeAnim();
    }

    public void StartFadeAnim()
    {
        // 애니메이션이 재생중이면 중복 재생되지 않도록 리턴 처리.  
        if (isPlaying == true)
            return;

        // Fade 애니메이션 재생.  
        StartCoroutine("PlayFadeOut");
    }

    IEnumerator PlayFadeOut()
    {
        // 애니메이션 재생중.  
        isPlaying = true;

        // Image 컴포넌트의 색상 값 읽어오기.  
        Color color = getCountRing.GetComponent<RawImage>().color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < 1f)
        {
            // 경과 시간 계산.  
            // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
            time += (Time.deltaTime / animTime);

            // 알파 값 계산.  
            color.a = Mathf.Lerp(start, end, time);
            // 계산한 알파 값 다시 설정.  
            getOriginalNote.GetComponent<RawImage>().color = color;
            getCountRing.GetComponent<RawImage>().color = color;

            getCountRing.transform.localScale = new Vector2(countSize, countSize);
            countSize -= 0.025f;

            yield return null;
        }

        // 애니메이션 재생 완료.  
        isPlaying = false;
        //Destroy(gameObject);

        

    }


    /*

    // Update is called once per frame
    void Update()
    {

        getCountRing.transform.localScale = new Vector2(countSize, countSize);
        countSize -= 0.02f;

        if (countSize <= 0.5f)
        {
            Destroy(gameObject);

        }

    }*/
}
