using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{

    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private Vector2 randomAngle;
    [SerializeField] private float spawnFrequency;
    [SerializeField] private int bubblesAmount;
    [SerializeField] private BubbleConfig[] bubbleConfigs;

    void Start()
    {
        StartCoroutine(SpawnBubbles());
    }

    private void Update()
    {
        // Spawn 10 bubbles at once
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnMultipleBubbles(bubblesAmount);
        }
    }

    public IEnumerator SpawnBubbles()
    {
        while (!gm.stopSpawningBubbles)
        {
            yield return new WaitForSeconds(spawnFrequency);
            randomAngle = Quaternion.Euler(0f, 0f, Random.Range(0, 360)) * Vector2.right * 7; // The 7 means that bubbles spawn at position 7,7 in a 360 degrees radius
            var bubble = Instantiate(bubblePrefab, randomAngle, Quaternion.identity, this.transform);
            bubble.GetComponent<BubbleBehaviour>().bubbleConfig = bubbleConfigs[Random.Range(0, bubbleConfigs.Length)];
            gm.totalBubbles += 1;
        }
    }

    private void SpawnMultipleBubbles(int bubblesAmount)
    {
        for (int i = 0; i < bubblesAmount; i++)
        {
            randomAngle = Quaternion.Euler(0f, 0f, Random.Range(0, 360)) * Vector2.right * 11;
            Instantiate(bubblePrefab, randomAngle, Quaternion.identity, this.transform);
            gm.totalBubbles += bubblesAmount;
        }
        Debug.Log("increase bubbles amount");
        this.bubblesAmount += 5;
    }
}
