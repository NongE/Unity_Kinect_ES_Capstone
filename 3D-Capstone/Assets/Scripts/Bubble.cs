using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
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


    private void Update()
    {
        time += Time.deltaTime;
        if (time > 1.5f)
        {
            transform.position = new Vector2(Random.Range(0.1f, 0), Random.Range(0, 0));
            // transform.position += mMovementDirection * Time.deltaTime * 0.5f;
            if (time > 5.0f)
            {
                if (flag == 0)
                {
                    gameObject.SetActive(false);
                    ScoreManager.score -= 5;
                }
            }
        }

    }

    private IEnumerator DirectionChanger()
    {

        while (gameObject.activeSelf)
        {
            //mMovementDirection = new Vector2(Random.Range(0, 50) * 0.01f, Random.Range(0, 50) * 0.01f);
            mMovementDirection = new Vector2(0,0);
            yield return new WaitForSeconds(3.0f);
        }
    }
}
