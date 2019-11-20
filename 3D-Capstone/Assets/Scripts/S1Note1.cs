using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1Note1 : MonoBehaviour
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

        if (Stage1BackgroundRepeat.audioSource.time > 2.5f)
        {

            GameObject.Find("Canvas").transform.Find("Note1").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Note1").gameObject.transform.position = new Vector3(660, 440, 0);

        }

        if (Stage1BackgroundRepeat.audioSource.time > 3.5f)
        {

            Stage1HPManager.hitFlag+=10 ;
            gameObject.SetActive(false);
        }
    }
}
