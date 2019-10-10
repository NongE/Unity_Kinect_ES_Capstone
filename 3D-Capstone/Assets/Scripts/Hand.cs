using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Hand : MonoBehaviour
{
    public Transform mHandMesh;
    public GameObject obj;

 
    private void Update()
    {

        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime*15.0f);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bubble"))
            return;

        else
        {

            Instantiate(obj, mHandMesh.position, Quaternion.identity);

            ScoreManager.score += 10;
            Bubble.flag = 1;
            

            collision.gameObject.SetActive(false);
            
            // obj.SecActive(false);
        }

    }

}
