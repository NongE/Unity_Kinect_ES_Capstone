using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualBubble : MonoBehaviour
{
    private Vector3 mMovementDirection = Vector3.zero;
    private Coroutine mCurrentChanger = null;
    private float time;
    public static int flag = 0;



    private void OnEnable()
    {
        mCurrentChanger = StartCoroutine(DirectionChanger());
    }

    private void OnDisable()
    {
        StopCoroutine(mCurrentChanger);
    }


    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }


    void Awake()
    {
        flag = 0;
    }

    private void Update()
    {

     
        if (flag == 0)
        {
           // transform.position = new Vector3(0, 0, 0);
        }
        /*
        // transform.position += mMovementDirection * Time.deltaTime * 0.5f;
        else if (flag == 1 && ManualHand.activeFlag == 1)
        {
            transform.position = new Vector3(0, 4, 0);
        }

        else if (flag == 2 && ManualHand.activeFlag == 2)
        {
            transform.position = new Vector3(3, 0, 0);
        }
        */

    }

    private IEnumerator DirectionChanger()
    {

        while (gameObject.activeSelf)
        {
            //mMovementDirection = new Vector2(Random.Range(0, 50) * 0.01f, Random.Range(0, 50) * 0.01f);
            mMovementDirection = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(3.0f);
        }
    }

}
