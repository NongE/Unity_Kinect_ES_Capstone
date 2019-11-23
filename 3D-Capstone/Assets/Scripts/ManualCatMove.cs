using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManualCatMove : MonoBehaviour
{
    float time;
    float catX = -4.8f;
    float catY = -2.5f;
    float catZ = -4f;


    int catFlag = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        GameObject.Find("Canvas").transform.Find("Cat").gameObject.transform.position = new Vector3(catX, catY, catZ); // 중앙
        if (ManualBackgroundRepeat.audioSource.time != 0)
        {

            catX += 0.0013f;
        }


    }

}
