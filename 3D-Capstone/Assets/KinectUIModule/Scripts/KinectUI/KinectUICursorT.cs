using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Windows.Kinect;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Collections;

public class KinectUICursorT : AbstractKinectUICursor
{
    public Color normalColor = new Color(1f, 1f, 1f, 0.5f);
    public Color hoverColor = new Color(1f, 1f, 1f, 1f);
    public Color clickColor = new Color(1f, 1f, 1f, 1f);
    public Vector3 clickScale = new Vector3(.8f, .8f, .8f);

    private Vector3 _initScale;

    public GameObject touchEffect;
    public GameObject healTouchEffect;

    public static int maxCombo =0;
    public static int comboCount = 0;
    public static int healCombo = 0;

    public override void Start()
    {
        base.Start();
        _initScale = transform.localScale;
        _image.color = new Color(1f, 1f, 1f, 0f);
    }

    public void OnTriggerEnter(Collider collision)
    {

   

        if (!collision.gameObject.CompareTag("Note"))
        {
            if (!collision.gameObject.CompareTag("HealNote"))
            {
                return;
            }
            else {

                Vector3 pos = (collision.bounds.center);

                Vector3 tmp;
                tmp.x = (pos.x - 960) / 100;
                tmp.y = (pos.y - 540) / 100;
                tmp.z = -1;


                float tmpCountSize = collision.gameObject.GetComponent<HealNote>().countSize;
                if (tmpCountSize <= 3.0f && tmpCountSize >= 2.0f)
                {
                    return;
                }
                else if (tmpCountSize < 2.0f && tmpCountSize >= 0.9f)
                {
                    Instantiate(healTouchEffect, tmp, Quaternion.identity, GameObject.Find("Canvas").transform);
                    ScoreManager.score += 10;
                    HPManager.hitFlag -= 10;
                    comboCount++;
                    healCombo++;
                    Destroy(collision.gameObject);
                }
                else {
                    Instantiate(healTouchEffect, tmp, Quaternion.identity, GameObject.Find("Canvas").transform);
                    ScoreManager.score += 5;
                    HPManager.hitFlag -= 5;
                    comboCount++;
                    healCombo++;
                    Destroy(collision.gameObject);
                }
                
            }
        }
        else
        {
           
            
            Vector3 pos = (collision.bounds.center);

            Vector3 tmp;
            tmp.x = (pos.x - 960)/100;
            tmp.y = (pos.y - 540) / 100;
            tmp.z = -1;
            

            
            //ScoreManager.score += 10;
            //Bubble.flag = 1;
            
            float tmpCountSize = collision.gameObject.GetComponent<testSphere>().countSize;
            if (tmpCountSize <= 3.0f && tmpCountSize >= 2.0f)
            {
                return;
            }
            else if (tmpCountSize < 2.0f && tmpCountSize >= 1.0f)
            {
                ScoreManager.score += 10;
                touchEffect.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Instantiate(touchEffect, tmp, Quaternion.identity, GameObject.Find("Canvas").transform);
                comboCount++;
                Destroy(collision.gameObject);
            }
            else if (tmpCountSize < 1.0f)
            {
                ScoreManager.score += 5;
                touchEffect.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Instantiate(touchEffect, tmp, Quaternion.identity, GameObject.Find("Canvas").transform);
                comboCount++;
                Destroy(collision.gameObject);
            }
            //collision.gameObject.SetActive(false);
            
            
        }

        if (comboCount > maxCombo)
        {
            maxCombo = comboCount;
        }

    }

    public override void ProcessData()
    {
        // update pos
        transform.position = _data.GetHandScreenPosition();
        if (_data.IsPressing)
        {
            _image.color = clickColor;
            _image.transform.localScale = clickScale;
            return;
        }
        if (_data.IsHovering)
        {
            _image.color = hoverColor;
        }
        else
        {
            _image.color = normalColor;
        }
        _image.transform.localScale = _initScale;

    }


}
