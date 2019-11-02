using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearStageTxt : MonoBehaviour
{

    Text clearStageTxt;

    void Awake()
    {
        clearStageTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        clearStageTxt.text = "스테이지 "+ StageNum.stageNum.ToString() +" 클리어!";
    }
}
