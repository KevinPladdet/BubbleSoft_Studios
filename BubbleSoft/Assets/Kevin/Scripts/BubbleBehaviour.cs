using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    [SerializeField] private float bubbleSpeed;
    [SerializeField] private float minSpeed;


    [SerializeField] private float speedMultiplier;
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private CircleCollider2D chainCollider;

    private Transform playerPos;
    private GameManager gm;
    private bool enableSlowdown = false;

    public BubbleConfig bubbleConfig;

    [SerializeField] private int destroyDelayInMs;
    [SerializeField] private List<BubbleBehaviour> chainedBubbles;
    [SerializeField] private bool isBeingDestroyed = false;
    [SerializeField] private float delayDestroyed = 0;

    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        chainedBubbles = new List<BubbleBehaviour>();
        GetComponent<SpriteRenderer>().sprite = bubbleConfig.sprite;
        health = bubbleConfig.health;
        damage = bubbleConfig.damage;
        speedMultiplier = bubbleConfig.speedMultiplier;

        // Rotates bubble so it faces towards the player
        Vector3 vectorToTarget = playerPos.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 270; // 270 makes it rotate perfectly towards the player
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = (q);
    }
    
    void Update()
    {
       if (isBeingDestroyed && delayDestroyed > 0)
        {
            delayDestroyed = delayDestroyed - Time.deltaTime * 1000;
            
        } else if (isBeingDestroyed && delayDestroyed <= 0) {
            Destroy(this.gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, (bubbleSpeed * speedMultiplier * gm.bubbleSpeedMultiplier) * Time.deltaTime);
        if (!enableSlowdown && bubbleSpeed >= minSpeed)
        {
            bubbleSpeed -= 0.15f * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"Collision started with: {collision.gameObject.name}");
        var collisionObject = collision.gameObject;

        if (collisionObject.tag == "Bubble")
        {
            chainedBubbles.Add(collisionObject.GetComponent<BubbleBehaviour>());

        } else if (collisionObject.tag == "Bullet")
        {
            Destroy(collisionObject);

            health -= 1;

            if (health < 1)
            {
                Bullet bullet = collisionObject.GetComponent<Bullet>();
                destroyBubble(bullet.type, 0);
            }

        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var collisionObject = collision.gameObject;
        if (collisionObject.tag == "Bubble")
        {
            chainedBubbles.Remove(collisionObject.GetComponent<BubbleBehaviour>());
        }
    }

    private void destroyBubble(ColorType type, int counterDelay)
    {
        if (isBeingDestroyed) return;

        isBeingDestroyed = true;
        delayDestroyed = counterDelay * destroyDelayInMs;
        Debug.Log("Delay destroyed: " + delayDestroyed);
        
        int localCurrentDelay = counterDelay;


        foreach (var bubble in chainedBubbles)
        {
            if ((int)bubble.bubbleConfig.type == (int)type)
            {
                localCurrentDelay++;
                bubble.destroyBubble(type, localCurrentDelay);
            }
        }



    }

}
