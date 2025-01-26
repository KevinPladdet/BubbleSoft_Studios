using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject OptionsMenu;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject PauseMenu1;
    [SerializeField] private GameObject Canvas;
    public TranslateScript text1;
    public TranslateScript text2;
    public TranslateScript text3;
    public TranslateScript text4;

    //[SerializeField] private GameObject healthBar;
    //[SerializeField] private GameObject objectives;
    public void StopTranslateSystem()
    {
        text1.enabled = false;
        text2.enabled = false;
        text3.enabled = false;
        text4.enabled = false;
    }
    public void Start()
    {
        Time.timeScale = 1f;
    }

    private bool isPaused = false;

    public bool canActivate = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            OnPause();
            Debug.Log("Opening Pause Menu");
        }

        if(Time.timeScale == 1f)
        {
            Debug.Log("Time is playing");
        }
        else if (Time.timeScale == 0f)
        {
            Debug.Log("Time Stopped");
        }
        
    }

    public void GoToGame()
    {
        Time.timeScale = 1f;
        canActivate = true;
        Debug.Log("Game opening, pause menu can activate");
    }

    public void gomenu()
    {
        Time.timeScale = 0f;
    }
    public void OnPause()
    {
        if (canActivate == true)
        {
            if (isPaused)
            {
                PauseMenu1.SetActive(false);
                Canvas.SetActive(false);
                OptionsMenu.SetActive(false);
               // healthBar.SetActive(true);
               // objectives.SetActive(true);
                Time.timeScale = 1f;
                isPaused = false;

            }
            else if (isPaused == false)
            {
                PauseMenu1.SetActive(true);
                Canvas.SetActive(false);
                MainMenu.SetActive(false);
                OptionsMenu.SetActive(false);
                //healthBar.SetActive(false);
               // objectives.SetActive(false);
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
    }

    public void ResumeGame()
    {

        PauseMenu1.SetActive(false);
        Canvas.SetActive(false);
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(false);
       // healthBar.SetActive(true);
      //  objectives.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        PauseMenu1.SetActive(false);
        Canvas.SetActive(true);
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
        // healthBar.SetActive(false);
        //  objectives.SetActive(false);
        Time.timeScale = 0f;
        isPaused = false;
        canActivate = false;
    }
}
