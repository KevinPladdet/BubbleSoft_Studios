using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

	[SerializeField] private int maxHealth = 100;

	[SerializeField] private Healthbar healthBar;

    [SerializeField] private GameManager gm;
    [SerializeField] private AudioManager am;
    [SerializeField] private Germ germScript;
    [SerializeField] private GameObject player;
    //private float elapsedTime = 0;

    void Start()
	{
		gm.currentHealth = maxHealth;
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
        if (gm.currentHealth == 10)
        {
            // Game Over Screen
            Debug.Log("player health dead");
            gm.currentHealth = 0;
            healthBar.SetHealth(gm.currentHealth);
            am.PlaySFX(am.gameOverSFX);
            gm.missionText.text = "Game Over!";
            StartCoroutine(am.WaitForResetScene());
            player.GetComponent<PlayerHealth>().enabled = false;
            germScript.enabled = false;
            player.GetComponent<Animator>().SetBool("Death", true);
            player.GetComponent<Animator>().speed = 0.3f;
        }
        else
        {
            am.PlaySFX(am.hurtSFX);
            gm.currentHealth -= damage;
            healthBar.SetHealth(gm.currentHealth);
        }
    }

    public void Heal()
    {
        am.PlaySFX(am.healSFX);
        while (gm.currentHealth < 100)
        {
            gm.currentHealth += 1;
            healthBar.SetHealth(gm.currentHealth);
        }
        healthBar.SetHealth(100);
    }
}
