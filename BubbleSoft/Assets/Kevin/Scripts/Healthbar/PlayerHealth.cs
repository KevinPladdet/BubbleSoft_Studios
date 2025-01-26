using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

	[SerializeField] private int maxHealth = 100;
	[SerializeField] private float currentHealth;

	[SerializeField] private Healthbar healthBar;

	[SerializeField] private AudioManager am;
    [SerializeField] private GameObject player;
    //private float elapsedTime = 0;

    void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	//void Update()
	//{
 //       ////elapsedTime += Time.deltaTime;
 //       //if (currentHealth == 100)
 //       //{

 //       //}
 //   }

    public void TakeDamage(int damage)
    {
        if (currentHealth == 10)
        {
            // Game Over Screen
            Debug.Log("player health dead");
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
            am.PlaySFX(am.gameOverSFX); // PUT GAME OVER SOUND HERE
            //StartCoroutine(am.WaitForResetScene());
            SceneManager.LoadScene("KevinScene");
            //player.SetActive(false);
        }
        else
        {
            am.PlaySFX(am.hurtSFX); // PUT DAMAGE SOUND HERE
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void Heal()
    {
        am.PlaySFX(am.healSFX);
        while (currentHealth < 100)
        {
            currentHealth += 1;
            healthBar.SetHealth(currentHealth);
        }
        healthBar.SetHealth(100);
    }
}
