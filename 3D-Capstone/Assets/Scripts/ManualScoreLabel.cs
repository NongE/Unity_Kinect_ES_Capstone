using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualScoreLabel : MonoBehaviour
{

    Text manualScoreLable;

    void Awake()
    {
        manualScoreLable = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        manualScoreLable.text = "Test Your Score! "+ManualScoreManager.manualScore.ToString();
    }
}
