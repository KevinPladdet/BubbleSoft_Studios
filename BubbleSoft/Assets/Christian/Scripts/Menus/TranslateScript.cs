using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class TranslateScript : MonoBehaviour
{
    public OptionsMenu optionsMenu;
    public string engishtext = "";
    public string spanishtext = "";
    public TMP_Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (optionsMenu.IsEnglish)
        {
            Text.text = engishtext;
        }
        else if(optionsMenu.IsSpanish)
        {
            Text.text = spanishtext;
        }
    }
}
