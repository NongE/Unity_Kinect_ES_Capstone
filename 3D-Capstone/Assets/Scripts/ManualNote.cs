using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManualNote : MonoBehaviour
{
    private Text hint; // 가이드 문구
    private float time; // 시간 관련
    public GameObject touchEffect;
    private int effectFlag = 0;
    Vector3 rightHand;
    Vector3 pos1;
    Vector3 leftHand;
    Vector3 pos2;

    // Start is called before the first frame update
    void Start()
    {
        time += Time.deltaTime; // 시간 시작
        GameObject.Find("Canvas").transform.Find("ManualToIntroBtn").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rightHand = GameObject.Find("Canvas").transform.Find("Image_Hand_Right").transform.position;
        leftHand = GameObject.Find("Canvas").transform.Find("Image_Hand_Left").transform.position;

        time += Time.deltaTime; // 시간 시작
        //Debug.Log(ManualKinectUICursor.activeFlag);
        hint = GameObject.Find("ManualTxt").GetComponent<Text>(); // 가이드 문구에 텍스트 오브젝트를 찾아 저장


        if (time > 4.0f && time < 6.5f) // 4.5~6.5초 사이
        {
            hint.GetComponent<Text>().text = "양팔을 벌려보세요!"; // 문구 변경
        }
        else if ((time > 6.5f && time < 10.0f) && (rightHand.y != leftHand.y))
        {

            rightHand = GameObject.Find("Canvas").transform.Find("Image_Hand_Right").transform.position;

            pos1.x = (rightHand.x - 960) / 100;
            pos1.y = (rightHand.y - 540) / 100;
            pos1.z = -1;


            leftHand = GameObject.Find("Canvas").transform.Find("Image_Hand_Left").transform.position;

            pos2.x = (leftHand.x - 960) / 100;
            pos2.y = (leftHand.y - 540) / 100;
            pos2.z = -1;


            if (effectFlag == 0)
            {
                Instantiate(touchEffect, pos1, Quaternion.identity, GameObject.Find("Canvas").transform);
                Instantiate(touchEffect, pos2, Quaternion.identity, GameObject.Find("Canvas").transform);
                effectFlag++; // 플래그 수치 변경으로 중복으로 이펙트가 발생하지 않도록 설정
            }


            hint.GetComponent<Text>().text = "잘했어요!";
        }

        if (time >= 10.0f && (rightHand.y != leftHand.y) && (rightHand.x != leftHand.x) && effectFlag == 0)
        {
            effectFlag += 1;
        }


        if (time > 10.0f && ManualKinectUICursor.activeFlag == 0 && effectFlag == 1) // 첫번째 메뉴얼 시작
        {

            hint.transform.position = new Vector2(960, 590); // 중앙
            hint.GetComponent<Text>().text = "여기에 손을 가져와보세요!";
            Debug.Log("첫번째 노트");
            GameObject.Find("Canvas").transform.Find("GameObject").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("GameObject").gameObject.transform.position = new Vector2(960, 540); // 중앙
        }


        else if (ManualKinectUICursor.activeFlag == 1 && effectFlag == 1) // 두번째 메뉴얼 시작
        {

            hint.transform.position = new Vector2(1300, 790); //오른쪽 상단
            hint.GetComponent<Text>().text = "이번에는 여기에요!";
            Debug.Log("두번째 노트");
            GameObject.Find("Canvas").transform.Find("GameObject").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("GameObject").gameObject.transform.position = new Vector2(1300, 740); //오른쪽 상단



        }
        else if (ManualKinectUICursor.activeFlag == 2 && effectFlag == 1) // 세번째 메뉴얼 시작
        {

            hint.transform.position = new Vector2(560, 390); //좌측 상단
            hint.GetComponent<Text>().text = "마지막이에요!";
            Debug.Log("세번째 노트");
            GameObject.Find("Canvas").transform.Find("GameObject").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("GameObject").gameObject.transform.position = new Vector2(560, 340); //좌측 상단

        }

        else if (ManualKinectUICursor.activeFlag == 3 && effectFlag == 1) // 메뉴얼 완료
        {
            hint.transform.position = new Vector2(960, 590); // 중앙
            hint.GetComponent<Text>().text = "여기에 손을 올리면 버튼을 누를 수 있어요!";
            ManualKinectUICursor.activeFlag++;
            GameObject.Find("Canvas").transform.Find("ManualToIntroBtn").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ManualToIntroBtn").gameObject.transform.position = new Vector2(960, 540); // 중앙
            //    Invoke("clicked", 2f);
        }
    }


}
