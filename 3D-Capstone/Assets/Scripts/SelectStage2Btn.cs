using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectStage2Btn : MonoBehaviour
{
    private Button _button;
    private Color _color;
    public Image _testImage;
    private AudioSource audioSource;

    private const float WAIT_TIME = 0.15f;

    private float waitTimer;
    public int currentIndex = 0;

    string infoText = "체육학과 체육학과 체육학과" + "\n\n" + "-체육학과-";
    private string typewriterText;
    public Text textInfo;

    private int playFlag = 0;
    private float inTimer;


    public float animTime = 1f;         // Fade 애니메이션 재생 시간 (단위:초). 
    private float start = 1f;           // Mathf.Lerp 메소드의 첫번째 값.  
    private float end = 0f;             // Mathf.Lerp 메소드의 두번째 값.  
    private float time = 0f;            // Mathf.Lerp 메소드의 시간 값.  

    private bool isPlaying = false;     // Fade 애니메이션의 중복 재생을 방지하기위해서 사용. 


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
        Color color = textInfo.GetComponent<Text>().color;

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

            textInfo.GetComponent<Text>().color = color;

            yield return null;
        }

        // 애니메이션 재생 완료.  
        isPlaying = false;
    }


    // Use this for initialization
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
        _color = new Color(255, 255, 255);
        // GetComponent<Image>().color = _color;
        _button.onClick.AddListener(() =>
        {
            //_testImage.color = _color;
            audioSource.Play();
            StageNum.stageNum = 1;
            playFlag = 1;

            //Invoke("clicked", 2f);

        });
    }


    void Update()
    {
        Debug.Log(inTimer);
        if (playFlag == 1)
        {
            inTimer += Time.deltaTime;
        }

        if (playFlag == 1 && inTimer >= 2.0f)
        {

            GameObject.Find("Canvas").transform.Find("IntroText").gameObject.SetActive(true);
            waitTimer += Time.deltaTime;
            if (waitTimer > WAIT_TIME && currentIndex < infoText.Length)
            {
                typewriterText += infoText[currentIndex];
                waitTimer = 0.0f;
                currentIndex++;
                textInfo.GetComponent<Text>().text = typewriterText;
            }
        }

        if (currentIndex == infoText.Length && inTimer >= 8)
        {
            StartFadeIn();
            playFlag++;
        }

        if (playFlag == 2)
        {
            Invoke("clicked", 1.0f);
        }

    }

    private void clicked()
    {

        SceneManager.LoadScene("Stage2Scene");
    }

}
