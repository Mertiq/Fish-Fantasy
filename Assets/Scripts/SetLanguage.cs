using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLanguage : MonoBehaviour
{

    public Text replay;
    public Text done;
    public Text lose;
    public Text resume;
    public Text replay2;
    public Text settings;
    public Text menu;
    public Text music;
    public Text sound;


    string[] Turkish = { "tekrar", "ileri", "tekrar dene", "DEVAM", "TEKRAR","AYARLAR", "MENU", "Müzik", "Ses"};
    string[] English = { "replay", "next", "try again", "RESUME", "REPLAY","SETTINGS", "MENU", "Music", "Sound"};


    private void Update()
    {
        if (Dropdown.eng)
        {
            replay.text = English[0];
            done.text = English[1];
            lose.text = English[2];
            resume.text = English[3];
            replay2.text = English[4];
            settings.text = English[5];
            menu.text = English[6];
            music.text = English[7];
            sound.text = English[8];
        }
        else{
            replay.text = Turkish[0];
            done.text = Turkish[1];
            lose.text = Turkish[2];
            resume.text = Turkish[3];
            replay2.text = Turkish[4];
            settings.text = Turkish[5];
            menu.text = Turkish[6];
            music.text = Turkish[7];
            sound.text = Turkish[8];
        }
    }


}
