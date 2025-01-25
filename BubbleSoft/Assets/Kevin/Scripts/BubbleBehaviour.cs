using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    [SerializeField] private float bubbleSpeed;
    [SerializeField] private float minSpeed;

    private Transform playerPos;
    private GameManager gm;
    private bool enableSlowdown = false;

    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, (bubbleSpeed * gm.bubbleSpeedMultiplier) * Time.deltaTime);
        if (!enableSlowdown && bubbleSpeed >= minSpeed)
        {
            bubbleSpeed -= 0.15f * Time.deltaTime;
        }
    }
}
