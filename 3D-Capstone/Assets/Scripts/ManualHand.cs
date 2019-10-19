using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class ManualHand : MonoBehaviour
{
    public Transform mHandMesh;
    public GameObject obj;
    private GameObject mb;

    private Text hint;
    private float time;

    public static int activeFlag = 0;


    private void Update()
    {

        hint = GameObject.Find("TouchHere").GetComponent<Text>();
        time += Time.deltaTime;

        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);
  

        if (activeFlag == 1)
        {

            hint.transform.position = new Vector2(1000,700);
            hint.GetComponent<Text>().text = "두번째 버블";
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.transform.position = new Vector2(0, 3);
     


        }
        else if (activeFlag == 2)
        {
    
            hint.transform.position = new Vector2(700, 1000);
            hint.GetComponent<Text>().text = "세번째 버블";
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.transform.position = new Vector2(3, 0);
            

        }

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
            
            hint.GetComponent<Text>().text = "Good!";

            
            





        }

    }

}
