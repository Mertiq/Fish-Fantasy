using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Dropdown : MonoBehaviour
{
    


    public static bool eng = true;


    
    
    public void ChangeLanguage(int index)
    {
        
        if (index == 1 && eng)
        {
            eng = false;
            PlayerPrefs.SetInt("lang", 0);
        }
        else
        {
                
            eng = true;
            PlayerPrefs.SetInt("lang", 1);
        }
        
        
    }
}
