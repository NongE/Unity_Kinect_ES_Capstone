using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Windows.Kinect;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ManualKinectUICursor : AbstractKinectUICursor
{
    public Color normalColor = new Color(1f, 1f, 1f, 0.5f);
    public Color hoverColor = new Color(1f, 1f, 1f, 1f);
    public Color clickColor = new Color(1f, 1f, 1f, 1f);
    public Vector3 clickScale = new Vector3(.8f, .8f, .8f);

    private Vector3 _initScale;


    public GameObject touchEffect;
    private Text hint; // 가이드 문구
    private float time; // 시간 관련
    public static int activeFlag = 0; // 플래그의 숫자에 따라 가이드 순서 결정

    public override void Start()
    {
        base.Start();
        _initScale = transform.localScale;
        _image.color = new Color(1f, 1f, 1f, 0f);
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

    public void OnTriggerEnter2D(Collider2D collision)
    {

       
        if (!collision.gameObject.CompareTag("Bubble"))
        {
       
            return;
        }
        else
        {
            Vector3 rightHand;
            Vector3 leftHand;

            rightHand = GameObject.Find("Canvas").transform.Find("Image_Hand_Right").transform.position;
            leftHand = GameObject.Find("Canvas").transform.Find("Image_Hand_Left").transform.position;
            if ((rightHand.x != leftHand.x) && (rightHand.y != leftHand.y))
            {
                Vector3 pos = (collision.bounds.center);
                Vector3 tmp;
                tmp.x = (pos.x - 960) / 100;
                tmp.y = (pos.y - 540) / 100;
                tmp.z = 0;

                Instantiate(touchEffect, tmp, Quaternion.identity, GameObject.Find("Canvas").transform);
                ManualScoreManager.manualScore += 10;
                activeFlag++;

                Debug.Log("노트와 충돌발생");

                collision.gameObject.SetActive(false);
            }

            // obj.SecActive(false);
        }

    }
    

    
}
