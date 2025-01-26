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

            var bubble = collision.gameObject.GetComponent<BubbleBehaviour>();
            bubble.onDestroyBubble();
        }
    }

    public void ResetCanShoot()
    {
        am.PlaySFX(am.shootSFX);
        germScript.canShoot = true;
        germScript.ShootBullet();
    }
}
