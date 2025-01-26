using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] bubblePopSFX;

    [Header("Audio Mixers")]
    [SerializeField] private AudioSource musicMixer;
    [SerializeField] private AudioSource sfxMixer;

    private int randomNumber;

    public void RandomBubblePopSFX()
    {
        sfxMixer.PlayOneShot(bubblePopSFX[Random.Range(0, bubblePopSFX.Length)]);
    }

    //private static VolumeManager instance;

    //public static VolumeManager Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = FindObjectOfType<VolumeManager>();
    //            if (instance == null)
    //            {
    //                GameObject obj = new GameObject("AudioManager");
    //                instance = obj.AddComponent<VolumeManager>();
    //            }
    //        }
    //        return instance;
    //    }
    //}

    

    //public void musicAudio()
    //{
    //    musicClip.volume = 1f;
    //}

    //// Every time a torch is lit
    //public void lightFireAudio()
    //{
    //    lightFireSFX.Play();
    //}

    //// When the torch stick gets picked up
    //public void pickUpAudio()
    //{
    //    pickUpSFX.Play();
    //}

    //// When the sword gets picked up
    //public void equipSwordAudio()
    //{
    //    equipSwordSFX.Play();
    //}

    //// When the door opens
    //public void openDoorAudio()
    //{
    //    openDoorSFX.Play();
    //}

    //// When the door closes
    //public void closeDoorAudio()
    //{
    //    closeDoorSFX.Play();
    //}

    //// When the sword falls and hits the throne
    //public void swordFallAudio()
    //{
    //    swordFallSFX.Play();
    //}

    //// When the sword swings
    //public void swordSwingAudio()
    //{
    //    swordSwingSFX.Play();
    //}

    //// When the enemy gets hit
    //public void boneHitAudio()
    //{
    //    boneHitSFX.Play();
    //}

    //// When the player dies
    //public void playerDeathAudio()
    //{
    //    playerDeathSFX.Play();
    //}

    //// When the player wins
    //public void playerWinAudio()
    //{
    //    winSFX.Play();
    //}

    // When the player gets bonked by a skeleton
    //public void bubblePopAudio()
    //{
    //    randomNumber = Random.Range(1, 4);
    //    switch (randomNumber)
    //    {
    //        case 1:
    //            playerHurtSFX.Play();
    //            break;
    //        case 2:
    //            playerHurtTwoSFX.Play();
    //            break;
    //        case 3:
    //            playerHurtThreeSFX.Play();
    //            break;
    //        default:
    //            Debug.Log("This option should never happen, if this shows up in console than check the problem out.");
    //            break;
    //    }
    //}
}