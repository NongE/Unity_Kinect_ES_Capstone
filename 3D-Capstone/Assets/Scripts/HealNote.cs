using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealNote : MonoBehaviour
{

    public float countSize;


    public GameObject getCountRing;
    public GameObject getOriginalNote;
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
            Destroy(gameObject);

        }

    }
}
