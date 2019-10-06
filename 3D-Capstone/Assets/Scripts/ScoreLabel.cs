using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLabel : MonoBehaviour
{

    Text scoreLable;

    void Awake()
    {
        scoreLable = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreLable.text = ScoreManager.score.ToString();
    }
}
