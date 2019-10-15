using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonTest : MonoBehaviour
{
    ///

    private Button _button;
    private Color _color;
    public Image _testImage;
    private AudioSource audioSource;



    // Use this for initialization
    void Start()
    {

        _button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
        _color = new Color(255, 255, 255);
        GetComponent<Image>().color = _color;
        _button.onClick.AddListener(() =>
        {

          
                 audioSource.Play();
                 Invoke("clicked", 2f);

               // _testImage.color = _color;
            });
    }

    private void clicked()
    {

        SceneManager.LoadScene("SelectStageScene");
    }


}
