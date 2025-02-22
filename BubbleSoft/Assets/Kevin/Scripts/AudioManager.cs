using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] bubblePopSFX;
    [SerializeField] private AudioClip[] wordSFX;
    public AudioClip healSFX;
    public AudioClip hurtSFX;
    public AudioClip waveEndsSFX;
    public AudioClip gameOverSFX;
    public AudioClip shootSFX;

    [Header("Audio Mixers")]
    [SerializeField] private AudioSource musicMixer;
    [SerializeField] private AudioSource sfxMixer;

    private int randomNumber;

    public void PlaySFX(AudioClip audioName)
    {
        sfxMixer.PlayOneShot(audioName);
    }

    public void RandomBubblePopSFX()
    {
        sfxMixer.PlayOneShot(bubblePopSFX[Random.Range(0, bubblePopSFX.Length)]);
    }

    public void RandomWordSFX()
    {
        sfxMixer.PlayOneShot(wordSFX[Random.Range(0, wordSFX.Length)]);
    }

    public IEnumerator WaitForResetScene()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0f;
        SceneManager.LoadScene("MainScene");
    }
}