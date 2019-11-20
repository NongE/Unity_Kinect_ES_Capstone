using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4Note5 : MonoBehaviour
{
  
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas").transform.Find("Note5").gameObject.transform.position = new Vector3(-1920, -1080, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
  
        if (Stage4BackgroundRepeat.audioSource.time > 11.1f)
        {
           
            GameObject.Find("Canvas").transform.Find("Note5").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Note5").gameObject.transform.position = new Vector3(600, 240, 0);

        }

        if (Stage4BackgroundRepeat.audioSource.time > 12.1f)
        {
            Stage4HPManager.hitFlag+=10 ;
            gameObject.SetActive(false);
        }
    }
}
