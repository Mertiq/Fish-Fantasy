using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("levelSelect01");
    }

    public void Pause(GameObject PausePanel)
    {
        LevelTimer.timeOut = true;
        PausePanel.SetActive(true);
    }

    public void Resume(GameObject PausePanel)
    {
        LevelTimer.timeOut = false;
        PausePanel.SetActive(false);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Settings(GameObject SettingsPanel)
    {
        SettingsPanel.SetActive(true);
    }
}
