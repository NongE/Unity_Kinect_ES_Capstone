using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btnIntrotoManualPage : MonoBehaviour
//public class ButtonTest : MonoBehaviour
{
    ///

    private Button _button;
    private Color _color;
    //public Image _testImage;
    private AudioSource audioSource;
    public GameObject obj;

    public GameObject btn;

    public float animTime = 1f;         // Fade 애니메이션 재생 시간 (단위:초). 
    private float start = 1f;           // Mathf.Lerp 메소드의 첫번째 값.  
    private float end = 0f;             // Mathf.Lerp 메소드의 두번째 값.  
    private float time = 0f;            // Mathf.Lerp 메소드의 시간 값.  

    private bool isPlaying = false;     // Fade 애니메이션의 중복 재생을 방지하기위해서 사용. 
    private int fadeFlag = 0;

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
        Color color = btn.GetComponent<Image>().color;

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

            btn.GetComponent<Image>().color = color;

            yield return null;
        }

        // 애니메이션 재생 완료.  
        fadeFlag = 1;
        isPlaying = false;
        
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
        Color color = btn.GetComponent<Image>().color;

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

            btn.GetComponent<Image>().color = color;

            yield return null;
        }

        // 애니메이션 재생 완료.  
        fadeFlag = 0;
        isPlaying = false;
        
    }


    // Use this for initialization
    void Start()
    {

        



        _button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
        _color = new Color(255, 255, 255);
        GetComponent<Image>().color = _color;
        _button.onClick.AddListener(() =>
        {
            audioSource.Play();
            //_button.gameObject.SetActive(false);
           // GameObject.Find("Canvas").transform.Find("StartBtn").gameObject.transform.position = new Vector2(-100, -100);
           // GameObject.Find("Canvas").transform.Find("ManualBtn").gameObject.transform.position = new Vector2(-100, -100);
            //Instantiate(obj, new Vector3(0, -3,5), Quaternion.identity);
            Invoke("clicked", 2f);

            // _testImage.color = _color;
        });
    }


    void Update()
    {
        //Debug.Log("flag is" + fadeFlag);

        if (fadeFlag == 1)
        {
            Debug.Log("StartFadeOut");
            start = 0f;
            end = 1f;
            StartFadeOut();
        }
        else if (fadeFlag == 0)
        {
            Debug.Log("StartFadeIn");
            start = 1f;
            end = 0f;
            StartFadeIn();
        }
    }

    private void clicked()
    {

        SceneManager.LoadScene("ManualScene");
    }


}
