using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{

    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private Vector2 randomAngle;
    [SerializeField] private float spawnFrequency;

    void Start()
    {
        StartCoroutine(SpawnBubbles());
    }

    private void Update()
    {
        // Spawn 10 bubbles at once
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnMultipleBubbles(10);
        }
    }

    private IEnumerator SpawnBubbles()
    {
        while (!gm.stopSpawningBubbles)
        {
            yield return new WaitForSeconds(spawnFrequency);
            randomAngle = Quaternion.Euler(0f, 0f, Random.Range(0, 360)) * Vector2.right * 7; // The 7 means that bubbles spawn at position 7,7 in a 360 degrees radius
            Instantiate(bubblePrefab, randomAngle, Quaternion.identity, this.transform);
            gm.totalBubbles += 1;
        }
    }

    private void SpawnMultipleBubbles(float bubblesAmount)
    {
        for (int i = 0; i < bubblesAmount; i++)
        {
            randomAngle = Quaternion.Euler(0f, 0f, Random.Range(0, 360)) * Vector2.right * 11;
            Instantiate(bubblePrefab, randomAngle, Quaternion.identity, this.transform);
            gm.totalBubbles += bubblesAmount;
        }
    }
}
