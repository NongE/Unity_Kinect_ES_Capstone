using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSceneClearEffect : MonoBehaviour
{
    private float time=0;
    private Vector3 tmp;
    private Vector3 tmp2;
    public GameObject effect;
    int effectCount = 0;
    int timeFlag = 0;
    int effectFlag = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; // 시간 시작
        //Debug.Log(effectCount);
        if (time > 1.9f && timeFlag == 0)
        {
         
            effectCount ++;
            timeFlag = 1;
           // setEffect(5, 0, -1, tmp);
           //  setEffect(5, 2, -1, tmp);
           //flag = 1;
        }

        if (effectCount == 1)
        {
            if (effectFlag == 0)
            {
                setEffect(3.5f, 0f, -1f, tmp);
                effectCount++;
            }
            else
            {
                setEffect(6f, 2f, -3f, tmp);
                effectCount++;
            }
        }

      //  if (effectCount == 2)
      //  {
      //      setEffect(6, 2, -2, tmp2);
      //      effectCount++;
      //  }

        if (effectCount == 2 && time > 2.0f )
        {
            time = 0;
            effectCount = 0;
            timeFlag = 0;
            if (effectFlag == 0) effectFlag = 1;
            else effectFlag = 0;
        }
  
    }

    private void setEffect(float x, float y, float z, Vector3 t)
    {
        t.x = x;
        t.y = y;
        t.z = z;
        Instantiate(effect, t, Quaternion.identity);//, GameObject.Find("Canvas").transform);
    }
}
