using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearStagePoint : MonoBehaviour
{

    Text clearStagePoint;
    /*public static int clearScore;

    void Awake()
    {
        clearScore = 0;
    }*/

    void Awake()
    {
        clearStagePoint = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        clearStagePoint.text = ScoreManager.score.ToString();
    }
}
