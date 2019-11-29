using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UGUI에 접근하려면 추가
using UnityEngine.SceneManagement;

public class Stage2BackgroundRepeat : MonoBehaviour
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
        timer += Time.deltaTime; // 시간 시작
        if (timer > 1.5 && playFlag == 0)
        {
            audioSource.Play();
            playFlag = 1;
        }

        if (audioSource.time >= musicTime && clearFlag == 0)
        {
            Debug.Log("Fade!");
            GameObject.Find("Fade Out").SendMessage("StartFadeAnim");
            Invoke("stageClear", 2f);
            clearFlag = 1;
        }


        Vector2 newOffset = thisMaterial.mainTextureOffset;
        // 새롭게 지정해줄 OffSet 객체를 선언합니다.
        newOffset.Set(newOffset.x + (scrollSpeed * Time.deltaTime), 0);
        // Y부분에 현재 y값에 속도에 프레임 보정을 해서 더해줍니다.
        thisMaterial.mainTextureOffset = newOffset;
        //그리고 최종적으로 Offset값을 지정해줍니다.

        if (audioSource.time >= 0.02f && noteCount == 1)
        {
            Instantiate(DamageObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;

        }
        if (audioSource.time >= 1.32f && noteCount == 2)
        {
            Instantiate(DamageObj, new Vector3(660, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(1260, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }//
        if (audioSource.time >= 2.31f && noteCount == 3)
        {
            Instantiate(DamageObj, new Vector3(960, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        //4

        if (audioSource.time >= 2.83f && noteCount == 4)
        {
            Instantiate(DamageObj, new Vector3(660, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 3.26f && noteCount == 5)
        {
            Instantiate(HealObj, new Vector3(960, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 3.97f && noteCount == 6)
        {
            Instantiate(HealObj, new Vector3(1260, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        //8
        if (audioSource.time >= 5.27f && noteCount == 7)
        {
            Instantiate(HealObj, new Vector3(660, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 5.574f && noteCount == 8)
        {
            Instantiate(HealObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 5.884f && noteCount == 9)
        {
            Instantiate(HealObj, new Vector3(660, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 6.516f && noteCount == 10)
        {
            Instantiate(HealObj, new Vector3(960, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        ///

        if (audioSource.time >= 7.793f && noteCount == 11)
        {
            Instantiate(HealObj, new Vector3(1260, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }


        if (audioSource.time >= 8.495f && noteCount == 12)
        {
            Instantiate(HealObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 9.12f && noteCount == 13)
        {
            Instantiate(HealObj, new Vector3(1260, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 10.355f && noteCount == 14)
        {
            Instantiate(HealObj, new Vector3(960, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        //18
        if (audioSource.time >= 11.691f && noteCount == 15)
        {
            Instantiate(HealObj, new Vector3(660, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(1260, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 11.953f && noteCount == 16)
        {
            Instantiate(HealObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 12.301f && noteCount == 17)
        {
            Instantiate(HealObj, new Vector3(660, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(1260, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        //21

        if (audioSource.time >= 12.918f && noteCount == 18)
        {
            Instantiate(HealObj, new Vector3(1260, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 13.625f && noteCount == 16)
        {
            Instantiate(HealObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 14.235f && noteCount == 17)
        {
            Instantiate(HealObj, new Vector3(1260, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 15.471f && noteCount == 18)
        {
            Instantiate(HealObj, new Vector3(960, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        //27

        if (audioSource.time >= 16.768f && noteCount == 19)
        {
            Instantiate(HealObj, new Vector3(660, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 17.14f && noteCount == 20)
        {
            Instantiate(HealObj, new Vector3(960, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 17.436f && noteCount == 21)
        {
            Instantiate(HealObj, new Vector3(1260, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        //31

        if (audioSource.time >= 18.1f && noteCount == 22)
        {
            Instantiate(HealObj, new Vector3(960, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 19.417f && noteCount == 23)
        {
            Instantiate(HealObj, new Vector3(960, 440, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        //34

        if (audioSource.time >= 20.647f && noteCount == 24)
        {
            Instantiate(HealObj, new Vector3(660, 740, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(1260, 740, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 21.933f && noteCount == 25)
        {
            Instantiate(HealObj, new Vector3(660, 440, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(1260, 440, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        //37

        if (audioSource.time >= 23.195f && noteCount == 26)
        {
            Instantiate(HealObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 24.539f && noteCount == 27)
        {
            Instantiate(HealObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        //40

        if (audioSource.time >= 25.766f && noteCount == 28)
        {
            Instantiate(HealObj, new Vector3(660, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 27.034f && noteCount == 29)
        {
            Instantiate(HealObj, new Vector3(1260, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        //43

        if (audioSource.time >= 28.373f && noteCount == 30)
        {
            Instantiate(HealObj, new Vector3(960, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 29.603f && noteCount == 31)
        {
            Instantiate(HealObj, new Vector3(660, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(1260, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 31.054f && noteCount == 32)
        {
            Instantiate(HealObj, new Vector3(960, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 32.213f && noteCount == 33)
        {
            Instantiate(HealObj, new Vector3(960, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        //

        if (audioSource.time >= 33.536f && noteCount == 34)
        {
            Instantiate(HealObj, new Vector3(660, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 34.789f && noteCount == 35)
        {
            Instantiate(HealObj, new Vector3(960, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 36.047f && noteCount == 36)
        {
            Instantiate(HealObj, new Vector3(960, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 37.382f && noteCount == 37)
        {
            Instantiate(HealObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }


        if (audioSource.time >= 39.924f && noteCount == 38)
        {
            Instantiate(HealObj, new Vector3(660, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(1260, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 41.221f && noteCount == 39)
        {
            Instantiate(HealObj, new Vector3(960, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 42.437f && noteCount == 40)
        {
            Instantiate(HealObj, new Vector3(960, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        //

        if (audioSource.time >= 43.783f && noteCount == 41)
        {
            Instantiate(HealObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 45.048f && noteCount == 42)
        {
            Instantiate(HealObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        //
        if (audioSource.time >= 46.348f && noteCount == 43)
        {
            Instantiate(HealObj, new Vector3(660, 780, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(1260, 780, 0), Quaternion.identity, GameObject.Find("Canvas").transform);

            noteCount++;
        }

        if (audioSource.time >= 47.615f && noteCount == 44)
        {
            Instantiate(HealObj, new Vector3(960, 380, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        //63
        if (audioSource.time >= 49.113f && noteCount == 45)
        {
            Instantiate(HealObj, new Vector3(960, 580, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 50.201f && noteCount == 46)
        {
            Instantiate(HealObj, new Vector3(960, 880, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 51.464f && noteCount == 47)
        {
            Instantiate(HealObj, new Vector3(660, 480, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(1260, 480, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 52.73f && noteCount == 48)
        {
            Instantiate(HealObj, new Vector3(660, 880, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }


        //70
        if (audioSource.time >= 54.016f && noteCount == 49)
        {
            Instantiate(HealObj, new Vector3(660, 480, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(1260, 480, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 55.452f && noteCount == 50)
        {
            Instantiate(HealObj, new Vector3(660, 780, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(1260, 780, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 56.602f && noteCount == 51)
        {
            Instantiate(HealObj, new Vector3(660, 560, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 57.896f && noteCount == 52)
        {
            Instantiate(HealObj, new Vector3(1260, 560, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 59.24f && noteCount == 53)
        {
            Instantiate(HealObj, new Vector3(960, 300, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        if (audioSource.time >= 60.576f && noteCount == 54)
        {
            Instantiate(HealObj, new Vector3(660, 800, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(HealObj, new Vector3(1260, 800, 0), Quaternion.identity, GameObject.Find("Canvas").transform);

            noteCount++;
        }



    }


    void stageClear()
    {
        SceneManager.LoadScene("ResultScene");
    }
}