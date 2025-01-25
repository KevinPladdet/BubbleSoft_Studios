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

    private Transform playerPos;
    private GameManager gm;
    private bool enableSlowdown = false;

    public BubbleConfig bubbleConfig;

    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        GetComponent<SpriteRenderer>().sprite = bubbleConfig.sprite;
        health = bubbleConfig.health;
        damage = bubbleConfig.damage;
        speedMultiplier = bubbleConfig.speedMultiplier;
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, (bubbleSpeed * speedMultiplier * gm.bubbleSpeedMultiplier) * Time.deltaTime);
        if (!enableSlowdown && bubbleSpeed >= minSpeed)
        {
            bubbleSpeed -= 0.15f * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision started with: {collision.gameObject.name}");
        var bullet = collision.gameObject;

        Destroy(bullet);

        health -= 1;

        if (health < 1)
        {
            Destroy(gameObject);
        }

    }


}
