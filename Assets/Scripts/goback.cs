using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class goback : MonoBehaviour   
{
     public Button gobackButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gobackButton.onClick.AddListener(switchScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void switchScene()
    {
        SceneManager.LoadScene("Booth");
    }
}
