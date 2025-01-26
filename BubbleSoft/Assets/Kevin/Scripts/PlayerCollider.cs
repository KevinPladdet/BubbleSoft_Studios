using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    [SerializeField] private GameManager gm;
    [SerializeField] private Germ germScript;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            gm.poppedBubbles += 1;
            //gm.missionText.text = "Objective: Survive 50 bubbles";

            if (gm.poppedBubbles == 50)
            {
                gm.stopSpawningBubbles = true;
                gm.missionText.color = new Color(0, 255, 0);
            }

            // Check if bubbles popped is 50, if yes stop spawning bubbles

            Destroy(collision.gameObject);
        }
    }

    public void ResetCanShoot()
    {
        germScript.canShoot = true;
        germScript.ShootBullet();
    }
}
