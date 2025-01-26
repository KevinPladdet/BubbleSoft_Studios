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
       SpawnMultipleBubbles(20);
    }

    private void Update()
    {
        // Spawn 10 bubbles at once
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnLimitNumberOfBubbles();
        }
    }

    public void SpawnLimitNumberOfBubbles()
    {
        var currentBubbleType = bubbleConfigs[Random.Range(0, bubbleConfigs.Length)];
        var currentAngle = Random.Range(0, 360);
        for (int i = 0; i < bubblesAmount; i++)
        {
            if (i % 5 == 0)
            {
                currentBubbleType = bubbleConfigs[Random.Range(0, bubbleConfigs.Length)];
                currentAngle = Random.Range(0, 360);
            }
            
            randomAngle = Quaternion.Euler(0f, 0f, currentAngle + Random.Range(-30, 30)) * Vector2.right * Random.Range(7, 13);
            var bubble = Instantiate(bubblePrefab, randomAngle, Quaternion.identity, this.transform);
            bubble.GetComponent<BubbleBehaviour>().bubbleConfig = currentBubbleType;

        }
        gm.totalBubbles += bubblesAmount;
        gm.currentWaveBubbles += bubblesAmount;
        this.bubblesAmount += 20;
    }

    public IEnumerator SpawnBubbles()
    {
        while (!gm.stopSpawningBubbles)
        {
            yield return new WaitForSeconds(spawnFrequency);
            randomAngle = Quaternion.Euler(0f, 0f, Random.Range(0, 360)) * Vector2.right * Random.Range(7, 13); // The 7 means that bubbles spawn at position 7,7 in a 360 degrees radius
            var bubble = Instantiate(bubblePrefab, randomAngle, Quaternion.identity, this.transform);
            bubble.GetComponent<BubbleBehaviour>().bubbleConfig = bubbleConfigs[Random.Range(0, bubbleConfigs.Length)];
            gm.totalBubbles += 1;
        }
    }

    private void SpawnMultipleBubbles(int bubblesAmount)
    {
        for (int i = 0; i < bubblesAmount; i++)
        {
            randomAngle = Quaternion.Euler(0f, 0f, Random.Range(0, 360)) * Vector2.right * Random.Range(7, 8);
            Instantiate(bubblePrefab, randomAngle, Quaternion.identity, this.transform);

        }
        gm.totalBubbles += bubblesAmount;
        gm.currentWaveBubbles += bubblesAmount;
        //Debug.Log("increase bubbles amount");
        //this.bubblesAmount += 5;
    }
}
