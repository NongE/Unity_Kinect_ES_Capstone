using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4Note3 : MonoBehaviour
{
  
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas").transform.Find("Note3").gameObject.transform.position = new Vector3(-1920, -1080, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
  
        if (Stage4BackgroundRepeat.audioSource.time > 7.5f)
        {
           
            GameObject.Find("Canvas").transform.Find("Note3").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Note3").gameObject.transform.position = new Vector3(460, 440, 0);

        }

        if (Stage4BackgroundRepeat.audioSource.time > 8.5f)
        {
            Stage4HPManager.hitFlag+=10 ;
            gameObject.SetActive(false);
        }
    }
}
