using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxCombo : MonoBehaviour
{

    Text maxComboTxt;

    void Awake()
    {
        maxComboTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        maxComboTxt.text = KinectUICursorT.maxCombo.ToString();
    }
}
