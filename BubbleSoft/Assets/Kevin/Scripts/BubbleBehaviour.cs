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
    private AudioManager am;
    private WaveManager ws;
    private bool enableSlowdown = false;

    public BubbleConfig bubbleConfig;

    [SerializeField] private int destroyDelayInMs;
    [SerializeField] private List<BubbleBehaviour> chainedBubbles;
    [SerializeField] private bool isBeingDestroyed = false;
    [SerializeField] private float delayDestroyed = 0;
    private int counterDelay = 0;
    private bool chainReactionTriggered = false;

    private bool onlyOnce = false;
    private float fadeDuration = 2f;

    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        ws = GameObject.Find("WaveManager").GetComponent<WaveManager>();

        ws.updateTextSurvive();

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
            if (chainReactionTriggered)
            {
                foreach (var bubble in chainedBubbles)
                {
                    bubble.counterDelay = counterDelay + 1;
                    bubble.destroyBubble(chainReactionTriggered, false);
                }

            }

            onDestroyBubble();
        }

        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, (bubbleSpeed * speedMultiplier * gm.bubbleSpeedMultiplier) * Time.deltaTime);
        if (!enableSlowdown && bubbleSpeed >= minSpeed)
        {
            bubbleSpeed -= 0.15f * Time.deltaTime;
        }

        if (gm.currentHealth == 0 && !onlyOnce)
        {
            StartCoroutine(FadeOutAndDestroy());
            onlyOnce = true;
        }
    }

    public void onDestroyBubble()
    {
        am.RandomBubblePopSFX();
        gm.poppedBubbles += 1;
        gm.currentWaveBubbles -= 1;
        ws.updateTextSurvive();

        if (gm.currentWaveBubbles <= 0)
        {
            ws.EndOfRound();
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            health -= 1;

            if (health == 1)
            {
                GetComponent<SpriteRenderer>().sprite = bubbleConfig.spriteOnHit;
            }
            else if (health < 1)
            {
                counterDelay = 0;
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                bool canTriggerChain = (int)bullet.bulletConfig.type == (int)bubbleConfig.type;
                destroyBubble(canTriggerChain, true);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"Collision started with: {collision.gameObject.name}");
        var collisionObject = collision.gameObject;

        if (collisionObject.tag == "Bubble")
        {
            var otherBubble = collisionObject.GetComponent<BubbleBehaviour>();
            if ((int)bubbleConfig.type == (int)otherBubble.bubbleConfig.type)
            {
                chainedBubbles.Add(collisionObject.GetComponent<BubbleBehaviour>());
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

    private void destroyBubble(bool triggeredChainReaction, bool force)
    {
        //if (isBeingDestroyed && !force) return;

        isBeingDestroyed = true;
        chainReactionTriggered = triggeredChainReaction;
        delayDestroyed = counterDelay * destroyDelayInMs;
    }

    private IEnumerator FadeOutAndDestroy()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        float startAlpha = color.a;
        float fadeSpeed = startAlpha / fadeDuration;

        // Gradually fade the alpha to 0
        while (color.a > 0)
        {
            color.a -= fadeSpeed * Time.deltaTime;
            GetComponent<SpriteRenderer>().color = color;

            yield return null;
        }

        Destroy(gameObject);
    }
}
