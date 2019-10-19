using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualScoreManager : MonoBehaviour
{
    public static int manualScore;

    void Awake()
    {
        manualScore = 0;
    }
}
