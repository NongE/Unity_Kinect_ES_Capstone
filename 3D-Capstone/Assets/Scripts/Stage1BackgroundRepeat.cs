using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1BackgroundRepeat : MonoBehaviour
{

    public float scrollSpeed;
    //스크롤할 속도를 로 지정해 줍니다.
    public static AudioSource audioSource;

    private Material thisMaterial;
    //Quad의 Material 데이터를 받아올 객체를 선언합니다.

    private int noteCount = 1;

    public GameObject DamageObj;
    public GameObject HealObj;

    public float timer;
    private int playFlag = 0;


    void Start()
    {
        Debug.Log(StageNum.stageNum);
        //객체가 생성될때 최초 1회만 호출 되는 함수 입니다.
        thisMaterial = GetComponent<Renderer>().material;
        //현재 객체의 Component들을 참조해 Renderer라는 컴포넌트의 Material정보를 받아옵니다.
        audioSource = GetComponent<AudioSource>();
    }

        void Update()
    {
        timer += Time.deltaTime; // 시간 시작
        if (timer > 3 && playFlag == 0)
        {
            audioSource.Play();
            playFlag = 1;
        }
       // Debug.Log("현재 타이머: "+ timer);
        Debug.Log(audioSource.time);

        Vector2 newOffset = thisMaterial.mainTextureOffset;
        // 새롭게 지정해줄 OffSet 객체를 선언합니다.
        newOffset.Set(newOffset.x + (scrollSpeed * Time.deltaTime), 0 );
        // Y부분에 현재 y값에 속도에 프레임 보정을 해서 더해줍니다.
        thisMaterial.mainTextureOffset = newOffset;
        //그리고 최종적으로 Offset값을 지정해줍니다.

        if (audioSource.time >= 0.01f && noteCount == 1)
        {
            Instantiate(DamageObj, new Vector3(660, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 0.01f && noteCount == 2)
        {
            Instantiate(DamageObj, new Vector3(1260, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }//
        if (audioSource.time >= 1.5f && noteCount == 3)
        {
            Instantiate(DamageObj, new Vector3(960, 840, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 2.4f && noteCount == 4)
        {
            Instantiate(DamageObj, new Vector3(960, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 3.4f && noteCount == 5)
        {
            Instantiate(DamageObj, new Vector3(1160, 740, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 3.6f && noteCount == 6)
        {
            Instantiate(HealObj, new Vector3(1160, 540, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 4.0f && noteCount == 7)
        {
            Instantiate(HealObj, new Vector3(600, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 4.2f && noteCount == 8)
        {
            Instantiate(HealObj, new Vector3(900, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }
        if (audioSource.time >= 4.9f && noteCount == 9)
        {
            Instantiate(HealObj, new Vector3(1200, 240, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            noteCount++;
        }


    }
}