using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ManualToInroBtn : MonoBehaviour {
    private Button _button;
    private Color _color;
    public RawImage _testImage;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
        _color = new Color(255, 255, 255);
       // GetComponent<Image>().color = _color;
        _button.onClick.AddListener(() =>
        {
            // _testImage.color = _color;
            audioSource.Play();
            GameObject.Find("Canvas").transform.Find("ManualToIntroBtn").gameObject.transform.position = new Vector2(-50, -50); // 중앙
            Invoke("clicked", 2f);

            
        });
	}

    private void clicked()
    {
        
        SceneManager.LoadScene("IntroScene");
    }

}
