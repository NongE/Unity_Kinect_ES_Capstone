using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBubble : MonoBehaviour
{
    private Vector3 mMovementDirection = Vector3.zero;
    private Coroutine mCurrentChanger = null;
   

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


    private void Update()
    {
        transform.position = new Vector3(6, -3, 0);
       
        

    }

    private IEnumerator DirectionChanger()
    {

        while (gameObject.activeSelf)
        {
            //mMovementDirection = new Vector2(Random.Range(0, 50) * 0.01f, Random.Range(0, 50) * 0.01f);
            mMovementDirection = new Vector3(0,0,0);
            yield return new WaitForSeconds(3.0f);
        }
    }
}
