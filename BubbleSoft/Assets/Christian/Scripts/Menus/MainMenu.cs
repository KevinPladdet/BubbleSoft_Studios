using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject objectives;

    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject bgCamera;

    [SerializeField] private GameObject onHoverText;

    private void Start()
    {
        Debug.Log(this.gameObject);
    }

    public void PlayGame()
    {
        this.gameObject.SetActive(false);
        healthBar.SetActive(true);
        objectives.SetActive(true);
        playerCamera.SetActive(true);
        bgCamera.SetActive(false);
        onHoverText.SetActive(true);
        Time.timeScale = 1f;
        pauseMenu.canActivate = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
