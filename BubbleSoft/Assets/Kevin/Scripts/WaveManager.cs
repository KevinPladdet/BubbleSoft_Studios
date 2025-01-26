using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [SerializeField] private GameManager gm;
    [SerializeField] private BubbleSpawner bs;

    public List<string> missionList = new List<string>();

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SelectMission();
        }
    }

    private void SelectMission()
    {
        string nextObjective;
        do
        {
            nextObjective = "Objective: " + missionList[Random.Range(0, missionList.Count)];
        } while (gm.missionText.text == nextObjective);
        gm.missionText.text = nextObjective;
        gm.missionText.color = new Color(0, 0, 0);

        gm.stopSpawningBubbles = false;
        StartCoroutine(bs.SpawnBubbles());
    }
}
