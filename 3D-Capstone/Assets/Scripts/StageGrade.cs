using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageGrade : MonoBehaviour
{

    Text stageGrade;
    public Text stageGradeTxt;
    /*public static int clearScore;

    void Awake()
    {
        clearScore = 0;
    }*/

    void Awake()
    {
        stageGrade = GetComponent<Text>();
        stageGradeTxt = GameObject.Find("Canvas").transform.Find("StageGradeTxt").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.score >=500)
        {
            stageGrade.text = "A+";
            stageGradeTxt.GetComponent<Text>().text = "오늘 저녁은 피자닷!";
        }
        else if (ScoreManager.score > 300 && ScoreManager.score <500)
        {
            stageGrade.text = "B+";
            stageGradeTxt.GetComponent<Text>().text = "비나이다...비나왔다";
        }
        else// if (ScoreManager.score < 300)
        {
            stageGrade.text = "C+";
            stageGradeTxt.GetComponent<Text>().text = "재수강 확정";
        }

    }
}
