using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UGUI에 접근하려면 추가
using UnityEngine.SceneManagement;

public class Stage3BackgroundRepeat : MonoBehaviour
{

    public float scrollSpeed;
    //스크롤할 속도를 로 지정해 줍니다.
    public static AudioSource audioSource;

    private Material thisMaterial;
    //Quad의 Material 데이터를 받아올 객체를 선언합니다.

    private int noteCount = 1;

    public GameObject DamageObj;
    public GameObject HealObj;

    public float timer;
    private int playFlag = 0;

    public float musicTime;
    private int clearFlag = 0;


    public GameObject colorMat;
    private int matFlag = 0;
    private float colorMatPos = -1920.0f;

    public Text introText;

    public AudioSource loadingSound;
    private int soundFlag = 0;

    void Start()
    {
        Debug.Log(StageNum.stageNum);
        //객체가 생성될때 최초 1회만 호출 되는 함수 입니다.
        thisMaterial = GetComponent<Renderer>().material;
        //현재 객체의 Component들을 참조해 Renderer라는 컴포넌트의 Material정보를 받아옵니다.
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // timer += Time.deltaTime; // 시간 시작

        if (colorMatPos < 960 && matFlag == 0)
        {
            colorMatPos += 50.0f;
            if (soundFlag == 0 && colorMatPos > 50.0f)
            {
                loadingSound.Play();
                soundFlag = 1;
            }
            if (colorMatPos >= 960.0f)
            {
                colorMatPos = 960;
                matFlag = 1;
            }
            colorMat.transform.position = new Vector2(colorMatPos, 540);
        }

        if (matFlag == 1)
        {
            timer += Time.deltaTime; // 시간 시작

            if (timer > 0.5f)
            {
                GameObject.Find("Canvas").transform.Find("IntroText").gameObject.SetActive(true);
            }

            if (timer > 2.5f)
            {
                if (colorMatPos < 3820.0f)
                {
                    colorMatPos += 50.0f;
                    colorMat.transform.position = new Vector2(colorMatPos, 540);
                    introText.transform.position = new Vector2(colorMatPos, 540);
                    if (colorMatPos >= 3820.0f)
                    {

                        matFlag = 2;
                        timer = 0.0f;
                    }
                }
            }
        }


        if (matFlag == 2 && playFlag == 0)
        {

            timer += Time.deltaTime; // 시간 시작

            //colorMat.gameObject.SetActive(false);
            //

            if (timer > 1.5f)
            {
                audioSource.Play();
                playFlag = 1;
                Destroy(colorMat);
                Destroy(introText.gameObject);
            }
        }

        if (audioSource.time >= musicTime && clearFlag == 0)
        {
            Debug.Log("Fade!");
            GameObject.Find("Fade Out").SendMessage("StartFadeAnim");
            Invoke("stageClear", 2f);
            clearFlag = 1;
        }

        //Debug.Log(audioSource.time);

        Vector2 newOffset = thisMaterial.mainTextureOffset;
        // 새롭게 지정해줄 OffSet 객체를 선언합니다.
        newOffset.Set(newOffset.x + (scrollSpeed * Time.deltaTime), 0);
        // Y부분에 현재 y값에 속도에 프레임 보정을 해서 더해줍니다.
        thisMaterial.mainTextureOffset = newOffset;
        //그리고 최종적으로 Offset값을 지정해줍니다.

        if (audioSource.time >= 0.2f && noteCount == 1)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(660, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(1260, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            
            noteCount++;
        }
        if (audioSource.time >= 1.034f && noteCount == 2)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }//
        if (audioSource.time >= 1.82f && noteCount == 3)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(760, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 3.32f && noteCount == 4)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(860, 440, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(960, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 4.79f && noteCount == 5)
        {
            Debug.Log(noteCount);
            Instantiate(HealObj, new Vector3(760, 440, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(660, 740, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 6.32f && noteCount == 6)
        {
            Debug.Log(noteCount);
            Instantiate(HealObj, new Vector3(560, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 6.32f && noteCount == 7)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1460, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 7.74f && noteCount == 8)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(860, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(960, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        //9
        if (audioSource.time >= 10.897f && noteCount == 9)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1160, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(960, 660, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 12.22f && noteCount == 10)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1060, 440, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(860, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 13.861f && noteCount == 10)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1060, 440, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(660, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        // 13
        if (audioSource.time >= 15.32f && noteCount == 11)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1060, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(1360, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 16.89f && noteCount == 12)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(760, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(960, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        // 16
        if (audioSource.time >= 18.52f && noteCount == 13)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1060, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(960, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 20.07f && noteCount == 14)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(960, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 21.493f && noteCount == 15)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(660, 740, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 21.593f && noteCount == 16)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 940, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(1260, 740, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 22.911f && noteCount == 17)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(460, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(660, 440, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 23.011f && noteCount == 18)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 640, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(1260, 440, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        //21

        if (audioSource.time >= 23.048f && noteCount == 19)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(960, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 24.469f && noteCount == 20)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(960, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 25.96f && noteCount == 20)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(960, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(960, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }


        if (audioSource.time >= 27.469f && noteCount == 21)
        {
            Debug.Log(noteCount);

            Instantiate(DamageObj, new Vector3(760, 740, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 27.769f && noteCount == 22)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1160, 740, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 28.096f && noteCount == 23)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(760, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 28.369f && noteCount == 24)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1160, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 28.669f && noteCount == 25)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1160, 440, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 28.966f && noteCount == 26)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(760, 440, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        //27



        if (audioSource.time >= 29.049f && noteCount == 27)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(960, 740, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 30.606f && noteCount == 28)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 30.900f && noteCount == 29)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }


        if (audioSource.time >= 32.172f && noteCount == 30)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 32.472f && noteCount == 31)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }


        // 31
        if (audioSource.time >= 33.899f && noteCount == 32)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(960, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 34.973f && noteCount == 33)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(960, 640, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        // 34

        if (audioSource.time >= 35.154f && noteCount == 34)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(660, 640, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 36.561f && noteCount == 35)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 640, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        // 37

        if (audioSource.time >= 38.187f && noteCount == 36)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(760, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 39.638f && noteCount == 37)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(760, 440, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        //40

        if (audioSource.time >= 41.165f && noteCount == 38)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1400, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 42.659f && noteCount == 39)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1400, 460, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        //43

        if (audioSource.time >= 44.12f && noteCount == 40)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(960, 800, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        //

        if (audioSource.time >= 45.735f && noteCount == 41)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(660, 850, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 46.035f && noteCount == 42)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 850, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 46.335f && noteCount == 43)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(660, 350, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 46.635f && noteCount == 44)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 350, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 46.935f && noteCount == 45)
        {
            Debug.Log(noteCount);
            //Instantiate(DamageObj, new Vector3(1260, 450, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 47.135f && noteCount == 46)
        {
            Debug.Log(noteCount);
            // Instantiate(DamageObj, new Vector3(1260, 450, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }



        // 46
        if (audioSource.time >= 47.317f && noteCount == 47)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(960, 800, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 48.667f && noteCount == 48)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 800, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 50.176f && noteCount == 49)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(660, 800, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 51.81f && noteCount == 50)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(960, 360, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }



        //51
        if (audioSource.time >= 53.219f && noteCount == 51)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(660, 460, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 53.519f && noteCount == 52)
        {
            Debug.Log(noteCount);
            //Instantiate(DamageObj, new Vector3(960, 560, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 55.819f && noteCount == 53)
        {
            Debug.Log(noteCount);
            // Instantiate(DamageObj, new Vector3(1260, 660, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 54.79f && noteCount == 54)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(960, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        //54
        if (audioSource.time >= 56.22f && noteCount == 55)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(960, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }


        if (audioSource.time >= 54.79f && noteCount == 56)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(660, 850, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 55.09f && noteCount == 57)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 850, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 55.39f && noteCount == 58)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(660, 650, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 55.69f && noteCount == 59)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 650, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 55.99f && noteCount == 60)
        {
            Debug.Log(noteCount);
            //Instantiate(DamageObj, new Vector3(660, 450, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 56.29f && noteCount == 61)
        {
            Debug.Log(noteCount);
            //Instantiate(DamageObj, new Vector3(1260, 450, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }


        //57


        if (audioSource.time >= 59.36f && noteCount == 62)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(960, 800, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }


        if (audioSource.time >= 60.72f && noteCount == 63)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(660, 850, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 61.02f && noteCount == 64)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(1260, 850, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }


        //60
        if (audioSource.time >= 62.28f && noteCount == 70)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(960, 350, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 63.891f && noteCount == 71)
        {
            Debug.Log(noteCount);
            Instantiate(DamageObj, new Vector3(960, 850, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

    }

    void stageClear()
    {
        SceneManager.LoadScene("ResultScene");
    }
}