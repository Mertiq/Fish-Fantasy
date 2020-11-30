using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject levelMenu;
    public GameObject settings;
    public GameObject menu;

    private void Awake()
    {

        Screen.SetResolution(1125, 2436, true);
    }

    public void Play()
    {
        levelMenu.SetActive(true);
        menu.SetActive(false);
    }
    public void Infinite()
    {
        SceneManager.LoadScene("Infinity");
    }
    public void Settings()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
