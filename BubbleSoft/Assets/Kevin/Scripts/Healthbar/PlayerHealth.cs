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
    //private float elapsedTime = 0;

	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	void Update()
	{
        //elapsedTime += Time.deltaTime;
        if (currentHealth == 100)
        {

        }

            if ((Input.GetKeyDown(KeyCode.O)))
		{
			Heal();
		}

        if ((Input.GetKeyDown(KeyCode.I)))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth == 20)
        {
            // Game Over Screen
            am.PlaySFX(am.gameOverSFX); // PUT GAME OVER SOUND HERE
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
