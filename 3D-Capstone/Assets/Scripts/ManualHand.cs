using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class ManualHand : MonoBehaviour
{
    public Transform mHandMesh;
    public GameObject obj; // 이펙트 관련 오브젝트
    private int objFlag = 0; // 센서 확인 후 이펙트가 한번만 작동하도록 하는 플래그
    private GameObject mb; // ManualBubble 오브젝트

    private Text hint; // 가이드 문구
    private float time; // 시간 관련

    public static int activeFlag = 0; // 플래그의 숫자에 따라 가이드 순서 결정
    //public int hintFlag = 0; // 


    private void Update()
    {

        hint = GameObject.Find("TouchHere").GetComponent<Text>(); // 가이드 문구에 텍스트 오브젝트를 찾아 저장
        time += Time.deltaTime; // 시간 시작
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f); // 손 추적


        if (time > 4.0f && time < 6.5f ) // 4.5~6.5초 사이
        {
            hint.GetComponent<Text>().text = "양팔을 벌려보세요!"; // 문구 변경
        }
        else if (time > 6.5f && time < 9.0f)
        {

            hint.GetComponent<Text>().text = "잘했어요!";
            if (objFlag == 0) Instantiate(obj, mHandMesh.position, Quaternion.identity); // 손 위치에 이펙트 발생
            objFlag++; // 플래그 수치 변경으로 중복으로 이펙트가 발생하지 않도록 설정
        }


        else if (time > 10.0f && activeFlag == 0) // 첫번째 메뉴얼 시작
        {
            hint.transform.position = new Vector2(960, 540);
            hint.GetComponent<Text>().text = "여기에 손을 가져와보세요!";
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.transform.position = new Vector2(0, 0);
        }


        if (activeFlag == 1) // 두번째 메뉴얼 시작
        {

            hint.transform.position = new Vector2(1000, 700);
            hint.GetComponent<Text>().text = "이번에는 여기에요!";
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.transform.position = new Vector2(0, 3);



        }
        else if (activeFlag == 2) // 세번째 메뉴얼 시작
        {

            hint.transform.position = new Vector2(700, 1000);
            hint.GetComponent<Text>().text = "마지막이에요!";
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.transform.position = new Vector2(3, 3);
           
        }

        else if (activeFlag == 3) // 메뉴얼 완료
        {
            GameObject.FindWithTag("FadeOut").SendMessage("StartFadeAnim");
            activeFlag++;
            Invoke("clicked", 2f);
        }

    }

    private void clicked()
    {
        SceneManager.LoadScene("IntroScene");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bubble"))
            return;

        else
        {

            Instantiate(obj, mHandMesh.position, Quaternion.identity);

            ManualScoreManager.manualScore += 10;
            activeFlag++;
            ManualBubble.flag++;

            mb = collision.gameObject;
            mb.gameObject.SetActive(false);
            hint.GetComponent<Text>().text = "좋아요!";

            
   


        }

    }

}
