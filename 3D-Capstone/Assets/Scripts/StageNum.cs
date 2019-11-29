using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageNum : MonoBehaviour
{
    public static int stageNum;

    void Awake()
    {
        stageNum = 0;
        KinectUICursorT.maxCombo = 0;
        KinectUICursorT.healCombo = 0;
        KinectUICursorT.comboCount = 0;
    }
}
