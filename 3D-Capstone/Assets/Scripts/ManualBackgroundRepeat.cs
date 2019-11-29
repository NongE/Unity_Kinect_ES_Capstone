using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManualBackgroundRepeat : MonoBehaviour
{

    public float scrollSpeed;
    //스크롤할 속도를 로 지정해 줍니다.
    public static AudioSource audioSource;

    private Material thisMaterial;
    //Quad의 Material 데이터를 받아올 객체를 선언합니다.

    private int noteCount = 1;

    public GameObject DamageObj;
    public GameObject HealObj;

    public float time;
    private int playFlag = 0;

    private Text hpHint; // 가이드 문구
    private Text progressHint; // 가이드 문구
    private Text pointHint; // 가이드 문구
    private Text exitBtnHint; // 가이드 문구
    private Text noteHint; // 가이드 문구

    private Vector3 rightHand;
    private Vector3 pos1;
    private Vector3 leftHand;
    private Vector3 pos2;

    public GameObject sensorCheckEffect;
    private int sensorCheckFlag=0;

    private int ManualCount = 0;


    void Start()
    {
        Debug.Log(StageNum.stageNum);
        //객체가 생성될때 최초 1회만 호출 되는 함수 입니다.
        thisMaterial = GetComponent<Renderer>().material;
        //현재 객체의 Component들을 참조해 Renderer라는 컴포넌트의 Material정보를 받아옵니다.
        audioSource = GetComponent<AudioSource>();

        GameObject.Find("Canvas").transform.Find("hpHint").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("progressHint").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("pointHint").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("exitBtnHint").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("noteHint").gameObject.SetActive(true);

        GameObject.Find("Canvas").transform.Find("ManualToIntroBtn").gameObject.SetActive(false);
    }


    void Update()
    {
 
        time += Time.deltaTime; // 시간 시작
        rightHand = GameObject.Find("Canvas").transform.Find("Image_Hand_Right").transform.position;
        leftHand = GameObject.Find("Canvas").transform.Find("Image_Hand_Left").transform.position;

        hpHint = GameObject.Find("Canvas").transform.Find("hpHint").GetComponent<Text>(); // 가이드 문구에 텍스트 오브젝트를 찾아 저장
        progressHint = GameObject.Find("Canvas").transform.Find("progressHint").GetComponent<Text>(); // 가이드 문구에 텍스트 오브젝트를 찾아 저장
        pointHint = GameObject.Find("Canvas").transform.Find("pointHint").GetComponent<Text>(); // 가이드 문구에 텍스트 오브젝트를 찾아 저장
        exitBtnHint = GameObject.Find("Canvas").transform.Find("exitBtnHint").GetComponent<Text>(); // 가이드 문구에 텍스트 오브젝트를 찾아 저장
        noteHint = GameObject.Find("Canvas").transform.Find("noteHint").GetComponent<Text>(); // 가이드 문구에 텍스트 오브젝트를 찾아 저장

        Vector2 newOffset = thisMaterial.mainTextureOffset;
        // 새롭게 지정해줄 OffSet 객체를 선언합니다.
        newOffset.Set(newOffset.x + (scrollSpeed * Time.deltaTime), 0);
        // Y부분에 현재 y값에 속도에 프레임 보정을 해서 더해줍니다.
        thisMaterial.mainTextureOffset = newOffset;
        //그리고 최종적으로 Offset값을 지정해줍니다.

      


        if (time > 4.0f && time < 6.5f && ManualCount == 0) // 4.5~6.5초 사이
        {
            GameObject.Find("Canvas").transform.Find("noteHint").gameObject.transform.position = new Vector2(960, 540); // 중앙
            GameObject.Find("Canvas").transform.Find("noteHint").gameObject.SetActive(true);
            noteHint.GetComponent<Text>().text = "양팔을 벌려보세요!"; // 문구 변경


            Invoke("checkSensor",2.5f);
           
        }
      

        if (time > 2.0f && ManualCount == 1)
        {
            noteHint.GetComponent<Text>().text = "타이밍에 맞춰 노트를 쳐보세요!";
            Instantiate(DamageObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            Instantiate(DamageObj, new Vector3(1260, 740, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            ManualCount++;
        }

        if (ScoreManager.score == 20 && ManualCount == 2)
        {
            noteHint.GetComponent<Text>().text = "이렇게 노트를 터트려서 점수를 얻을 수 있어요!!";
            time = 0;
            ManualCount++;
        }

        if (time > 2.0f && ManualCount == 3)
        {
            noteHint.GetComponent<Text>().text = "이번에는 초록색 링을 가진 노트를 쳐보세요!";
            Instantiate(HealObj, new Vector3(960, 760, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            ManualCount++;
        }

        if (ScoreManager.score == 30 && ManualCount == 4)
        {
            noteHint.GetComponent<Text>().text = "초록색 링을 가진 노트를 터트리면 체력이 회복되요!";
            time = 0;
            ManualCount++;
        }

        if (time > 4.0f && ManualCount == 5)
        {
            noteHint.GetComponent<Text>().text = "버튼에 손을 올려두면 버튼을 누를 수 있어요!";
            //Instantiate(HealObj, new Vector3(960, 340, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            GameObject.Find("Canvas").transform.Find("ManualToIntroBtn").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ManualToIntroBtn").gameObject.transform.position = new Vector2(960, 340);
            ManualCount++;
            
        }

        /*
        if (audioSource.time >= 0.2f && noteCount == 1)
        {
            Instantiate(DamageObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 0.2f && noteCount == 2)
        {
            Instantiate(DamageObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }//
        if (audioSource.time >= 1.5f && noteCount == 3)
        {
            Instantiate(DamageObj, new Vector3(960, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 2.4f && noteCount == 4)
        {
            Instantiate(DamageObj, new Vector3(960, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 3.4f && noteCount == 5)
        {
            Instantiate(DamageObj, new Vector3(1160, 740, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 3.6f && noteCount == 6)
        {
            Instantiate(HealObj, new Vector3(1160, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 4.0f && noteCount == 7)
        {
            Instantiate(HealObj, new Vector3(600, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 4.2f && noteCount == 8)
        {
            Instantiate(HealObj, new Vector3(900, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 4.9f && noteCount == 9)
        {
            Instantiate(HealObj, new Vector3(1200, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }

        */
    }


    private void checkSensor()
    {
        if ((rightHand.y != leftHand.y))
        {
            rightHand = GameObject.Find("Canvas").transform.Find("Image_Hand_Right").transform.position;

            pos1.x = (rightHand.x - 960) / 100;
            pos1.y = (rightHand.y - 540) / 100;
            pos1.z = -1;


            leftHand = GameObject.Find("Canvas").transform.Find("Image_Hand_Left").transform.position;

            pos2.x = (leftHand.x - 960) / 100;
            pos2.y = (leftHand.y - 540) / 100;
            pos2.z = -1;


            if (sensorCheckFlag == 0)
            {
                Instantiate(sensorCheckEffect, pos1, Quaternion.identity, GameObject.Find("Canvas").transform);
                Instantiate(sensorCheckEffect, pos2, Quaternion.identity, GameObject.Find("Canvas").transform);
                sensorCheckFlag++; // 플래그 수치 변경으로 중복으로 이펙트가 발생하지 않도록 설정
                noteHint.GetComponent<Text>().text = "센서가 확인되었어요";

            }

            noteHint = GameObject.Find("Canvas").transform.Find("noteHint").GetComponent<Text>();
            if (noteHint.text == "센서가 확인되었어요")
            {
                Debug.Log("check ok");
                ManualCount++;
                time = 0.0f;

                noteHint.GetComponent<Text>().text = "센서가 확인되었어요!";
                //Invoke("countPlus", 3.0f);
            }

            
        }
    }

    private void countPlus()
    {
  
       ManualCount++;
        time = 0.0f;

    }
}