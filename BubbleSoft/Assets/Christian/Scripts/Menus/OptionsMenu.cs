using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private GameObject player;

    public bool IsSpanish;
    public bool IsEnglish;
    public float sensValueForDisplay;

    private void Start()
    {


        List<string> options = new List<string>();

        
    }


    public void SetSpanish()
    {
        IsSpanish = true;
        IsEnglish = false;
    }

    public void SetEnglish()
    {
        IsEnglish = true;
        IsSpanish = false;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetMusic(float musicVolume)
    {
        musicMixer.SetFloat("musicVolume", musicVolume);
    }

    public void SetSensitivity(float sens)
    {
        //player.GetComponent<PlayerController>().sensitivity = sens;
        sensValueForDisplay = sens;
    }
}
