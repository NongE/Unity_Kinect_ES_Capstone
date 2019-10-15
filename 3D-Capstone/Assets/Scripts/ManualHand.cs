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

    private int activeFlag = 0;


    private void Update()
    {
        hint = GameObject.Find("TouchHere").GetComponent<Text>();
        time += Time.deltaTime;

        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);

        if (time > 6f && ManualBubble.flag == 1 && activeFlag == 0)
        {
            Debug.Log("Active");
            hint.transform.position = new Vector3(100,100,0);
            GameObject.Find("Canvas").transform.Find("ManualBubble").gameObject.SetActive(true);
            activeFlag = 1;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bubble"))
            return;

        else
        {

            Instantiate(obj, mHandMesh.position, Quaternion.identity);

            ScoreManager.score += 10;
            ManualBubble.flag = 1;
            
            mb = collision.gameObject;
            mb.gameObject.SetActive(false);
            //mb.gameObject.transform.Translate(0f, 5f, 0f);
          //  Debug.Log(mb.gameObject.active);
           // Debug.Log(mb.gameObject.activeInHierarchy);
            
            hint.GetComponent<Text>().text = "Good!";

            
            





        }

    }

}
