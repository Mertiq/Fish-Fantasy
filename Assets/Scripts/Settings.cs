using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer soundMixer;
    public GameObject panel;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetSound(float volume)
    {
        soundMixer.SetFloat("blup", volume);
    }

    public void Back(GameObject menu)
    {
        panel.SetActive(false);
        menu.SetActive(true);
    }

    public void BacktoGame()
    {
        panel.SetActive(false);
    }
    public void Reset()
    {
        LevelSelect.delete = true;
    }
}
