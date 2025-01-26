using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    [SerializeField] private GameManager gm;
    [SerializeField] private Germ germScript;
    [SerializeField] private AudioManager am;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            gm.poppedBubbles += 1;
            am.RandomBubblePopSFX();

            if (gm.poppedBubbles == 50)
            {
                gm.stopSpawningBubbles = true;
                gm.missionText.color = new Color(0, 255, 0);
            }

            Destroy(collision.gameObject);
        }
    }

    public void ResetCanShoot()
    {
        am.PlaySFX(am.shootSFX);
        germScript.canShoot = true;
        germScript.ShootBullet();
    }
}
