using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameScene;
    public string demo;
    public string twitter;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenURL()
    {
        Application.OpenURL(twitter);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void Demo()
    {
        SceneManager.LoadScene(demo);

    }

    public void Exit()
    {
        Application.Quit();
    }
}
