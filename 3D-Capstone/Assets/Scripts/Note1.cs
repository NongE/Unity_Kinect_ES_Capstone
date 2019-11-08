using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note1 : MonoBehaviour
{
    private float time;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas").transform.Find("Note1").gameObject.transform.position = new Vector3(-500, -500, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime;
        if (time > 1.5f)
        {
           
            GameObject.Find("Canvas").transform.Find("Note1").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Note1").gameObject.transform.position = new Vector3(660, 440, 0);

        }

        if (time > 3.0f)
        {
            HPManager.hitFlag+=10 ;
            gameObject.SetActive(false);
        }
    }
}
