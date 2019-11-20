using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4Note4 : MonoBehaviour
{
  
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas").transform.Find("Note4").gameObject.transform.position = new Vector3(-1920, -1080, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
  
        if (Stage4BackgroundRepeat.audioSource.time > 9.8f)
        {
           
            GameObject.Find("Canvas").transform.Find("Note4").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Note4").gameObject.transform.position = new Vector3(1500, 240, 0);

        }

        if (Stage4BackgroundRepeat.audioSource.time > 10.8f)
        {
            Stage4HPManager.hitFlag+=10 ;
            gameObject.SetActive(false);
        }
    }
}
