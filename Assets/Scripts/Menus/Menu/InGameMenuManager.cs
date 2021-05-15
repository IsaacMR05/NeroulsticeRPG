using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuManager : MonoBehaviour
{

    public GameObject inGameMenu;
    public GameObject inGameOptions;
    public GameObject inGameControlers;
    public MenuManager menuManager;

    private bool inGameMenuState;
    private bool inGameOptionsState;
    private bool inGameControlersState;



    // Start is called before the first frame update
    void Start()
    {
        inGameMenuState = menuManager.menuState;
    }

    // Update is called once per frame
    void Update()
    {
        inGameMenuState = menuManager.menuState;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ExitOptionsMenu()
    {
        inGameOptions.SetActive(false);
    }

    public void ExitControlersMenu()
    {
        inGameControlers.SetActive(false);
    }

    public void Resume()
    {
        menuManager.menuState = false;
        inGameMenu.SetActive(menuManager.menuState);
    }

    public void Options()
    {
        inGameOptions.SetActive(true);
    }

    public void Controlers()
    {
        inGameControlers.SetActive(true);
    }
}
