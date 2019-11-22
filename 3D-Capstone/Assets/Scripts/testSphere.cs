﻿using System.Collections;
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
    public GameObject brokenHeartEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        getCountRing.transform.localScale = new Vector2(countSize, countSize);
        countSize -= 0.02f;

        if (countSize <= 0.5f)
        {
            Vector3 pos = transform.position;

            Vector3 tmp;
            tmp.x = (pos.x - 960) / 100;
            tmp.y = (pos.y - 540) / 100;
            tmp.z = -1f;
         

            Instantiate(brokenHeartEffect, tmp, Quaternion.identity);

            ScoreManager.score -= 10;
            Stage4HPManager.hitFlag += 10;
            Destroy(gameObject);

        }
    }
}
