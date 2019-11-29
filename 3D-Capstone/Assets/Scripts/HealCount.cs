using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealCount : MonoBehaviour
{

    Text healCountTxt;

    void Awake()
    {
        healCountTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healCountTxt.text = KinectUICursorT.healCombo.ToString();
    }
}
