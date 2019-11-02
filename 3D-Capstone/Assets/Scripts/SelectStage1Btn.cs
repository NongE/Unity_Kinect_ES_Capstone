using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectStage1Btn : MonoBehaviour {
    private Button _button;
    private Color _color;
    public Image _testImage;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
        _color = new Color(255, 255, 255);
       // GetComponent<Image>().color = _color;
        _button.onClick.AddListener(() =>
        {
            //_testImage.color = _color;
            audioSource.Play();
            StageNum.stageNum = 1;
            Invoke("clicked", 2f);
            
        });
	}

    private void clicked()
    {

        SceneManager.LoadScene("Stage1Scene");
    }

}
