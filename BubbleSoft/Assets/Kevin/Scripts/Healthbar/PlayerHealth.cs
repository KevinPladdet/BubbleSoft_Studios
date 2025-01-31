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

    void Start()
	{
		gm.currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

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
        StartCoroutine(HealOverTime(2f)); // Heal to 100 over 2 seconds
    }

    // Loops healing until currentHealth is 100
    private IEnumerator HealOverTime(float duration)
    {
        float elapsedTime = 0f;
        float startHealth = gm.currentHealth;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            gm.currentHealth = Mathf.RoundToInt(Mathf.Lerp(startHealth, 100, elapsedTime / duration));
            healthBar.SetHealth(gm.currentHealth);

            if (gm.currentHealth >= 100)
            {
                gm.currentHealth = 100;
                healthBar.SetHealth(gm.currentHealth);
                yield break;
            }
            yield return null;
        }
    }
}
