using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLanguage2 : MonoBehaviour
{
    public Text settingsMusic;
    public Text settingsSound;
    public Text settingsReset;

    public Text menuPlay;
    public Text menuInfinity;
    public Text menuSettings;
    public Text menuExit;

    public Text levelText1;
    public Text levelText2;

    string[] Turkish = { "Müzik", "Ses", "Sıfırla", "OYNA", "SONSUZ MOD",
        "AYARLAR", "ÇIKIŞ" , "DAHA FAZLA LEVEL GÖRMEK İÇİN OYNAMAYA DEVAM ET"};
    string[] English = { "Music", "Sound", "Reset", "PLAY", "INFINITY MODE",
        "SETTINGS", "EXIT", "TO SEE MORE LEVELS KEEP PLAYING"};



    private void Update()
    {
        if (!Dropdown.eng)
        {
            settingsMusic.text = Turkish[0];
            settingsSound.text = Turkish[1];
            settingsReset.text = Turkish[2];
            menuPlay.text = Turkish[3];
            menuInfinity.text = Turkish[4];
            menuSettings.text = Turkish[5];
            menuExit.text = Turkish[6];
            levelText1.text = Turkish[7];
            levelText2.text = Turkish[7];
        }
        else{
            settingsMusic.text = English[0];
            settingsSound.text = English[1];
            settingsReset.text = English[2];
            menuPlay.text = English[3];
            menuInfinity.text = English[4];
            menuSettings.text = English[5];
            menuExit.text = English[6];
            levelText1.text = English[7];
            levelText2.text = English[7];
        }
    }


}
