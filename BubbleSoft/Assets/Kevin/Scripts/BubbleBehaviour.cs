using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{

    [SerializeField] private Transform playerPos;
    [SerializeField] private GameManager gm;
    [SerializeField] private float bubbleSpeed;
    private bool enableSlowdown = false;

    void Start()
    {
        // Tomorrow: make it so that the bubbles spawn outside of "WaterArea" and that they slowly go towards the player
        // (eventually make it so that they start fast and go slower the closer they get to the player)
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, (bubbleSpeed * gm.bubbleSpeedMultiplier) * Time.deltaTime);
        if (!enableSlowdown && bubbleSpeed >= 0.40f)
        {
            bubbleSpeed -= 0.15f * Time.deltaTime;
        }
    }
}
