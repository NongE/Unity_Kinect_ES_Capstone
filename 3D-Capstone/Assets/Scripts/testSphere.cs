using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class testSphere : MonoBehaviour
{

    public float countSize;


    public GameObject getCountRing;
    public GameObject getOriginalNote;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
        getCountRing.transform.localScale = new Vector2(countSize, countSize);
        countSize -= 0.02f;

        if (countSize <= 0.2f)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
            //getOriginalNote.gameObject.SetActive(false);
            ScoreManager.score -= 10;
            Stage4HPManager.hitFlag += 10;
        }

    }
}
