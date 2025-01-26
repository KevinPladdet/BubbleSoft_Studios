using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] bubblePopSFX;
    [SerializeField] private AudioClip[] wordSFX;

    [Header("Audio Mixers")]
    [SerializeField] private AudioSource musicMixer;
    [SerializeField] private AudioSource sfxMixer;

    private int randomNumber;

    public void RandomBubblePopSFX()
    {
        sfxMixer.PlayOneShot(bubblePopSFX[Random.Range(0, bubblePopSFX.Length)]);
    }

    public void RandomWordSFX()
    {
        sfxMixer.PlayOneShot(wordSFX[Random.Range(0, wordSFX.Length)]);
    }
}