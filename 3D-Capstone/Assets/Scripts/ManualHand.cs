using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManualHand : MonoBehaviour
{
    public Transform mHandMesh;
    public GameObject obj;
    private int objFlag = 0;
    private GameObject mb;

    private Text hint;
    private float time;

    public static int activeFlag = 0;
    public int hintFlag = 0;


    private void Update()
    {

        hint = GameObject.Find("TouchHere").GetComponent<Text>();
        time += Time.deltaTime;
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);


        if (time > 4.0f && time < 6.5f )
        {
            hint.GetComponent<Text>().text = "양팔을 벌려보세요!";
        }
        else if (time > 6.5f && time < 9.0f)
        {

            hint.GetComponent<Text>().text = "잘했어요!";
            if (objFlag == 0) Instantiate(obj, mHandMesh.position, Quaternion.identity);
            objFlag++;
        }


        else if (time > 10.0f && activeFlag == 0)
        {
            hint.transform.position = new Vector2(960, 540);
            hint.GetComponent<Text>().text = "여기에 손을 가져와보세요!";
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.transform.position = new Vector2(0, 0);
        }


        if (activeFlag == 1)
        {

            hint.transform.position = new Vector2(1000, 700);
            hint.GetComponent<Text>().text = "이번에는 여기에요!";
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.transform.position = new Vector2(0, 3);



        }
        else if (activeFlag == 2)
        {

            hint.transform.position = new Vector2(700, 1000);
            hint.GetComponent<Text>().text = "마지막이에요!";
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.transform.position = new Vector2(3, 3);
           
        }

        else if (activeFlag == 3)
        {
            GameObject.FindWithTag("Fade").SendMessage("StartFadeAnim");
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
