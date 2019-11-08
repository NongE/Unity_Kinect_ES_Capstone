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


    public override void Start()
    {
        base.Start();
        _initScale = transform.localScale;
        _image.color = new Color(1f, 1f, 1f, 0f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

       
        if (!collision.gameObject.CompareTag("Note"))
        {
       
            return;
        }
        else
        {
            //coll.contacts[0].point;
           
            Vector3 pos = (collision.bounds.center);
           // Debug.Log(collision.bounds.center.x);

            Vector3 tmp;
            tmp.x = (pos.x - 960)/100;
            tmp.y = (pos.y - 540) / 100;
            tmp.z = 0;

            Instantiate(touchEffect, tmp, Quaternion.identity, GameObject.Find("Canvas").transform);


            ScoreManager.score += 10;
            Bubble.flag = 1;

            //Debug.Log("충돌, 버블임");
            collision.gameObject.SetActive(false);

            // obj.SecActive(false);
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
