using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonTest : MonoBehaviour {
    private Button _button;
    private Color _color;
    public Image _testImage;
	// Use this for initialization
	void Start () {
        _button = GetComponent<Button>();
        _color = new Color(255, 255, 255);
        GetComponent<Image>().color = _color;
        _button.onClick.AddListener(() =>
        {
            //_testImage.color = _color;
            SceneManager.LoadScene("SelectStageScene");
           // UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("SelectMusicScene");
        });
	}
	
}
