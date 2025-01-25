using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("Difficulty Values")]
    public float bubbleSpeedMultiplier;

    [Header("Other Values")]
    public float totalBubbles;
    public float poppedBubbles;
    public bool stopSpawningBubbles;

    [Header("References")]
    public TextMeshProUGUI missionText;
}