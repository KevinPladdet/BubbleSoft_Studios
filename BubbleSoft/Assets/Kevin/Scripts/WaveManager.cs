using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [SerializeField] private GameManager gm;
    [SerializeField] private BubbleSpawner bs;

    public List<string> missionList = new List<string>();
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SelectMission();
        }
    }

    public void SelectMission()
    {
        string nextObjective;
        do
        {
            nextObjective = "Objective: " + missionList[Random.Range(0, missionList.Count)];
        } while (gm.missionText.text == nextObjective);
        gm.missionText.text = nextObjective;
        gm.missionText.color = new Color(0, 0, 0);

        bs.SpawnLimitNumberOfBubbles();
        // gm.stopSpawningBubbles = false;
       // StartCoroutine(bs.SpawnBubbles());

    }

    public void updateTextSurvive()
    {
        gm.missionText.text = "Objective: Survive " + gm.currentWaveBubbles + " bubbles!";
    }
    public void EndOfRound()
    {
        StartCoroutine(_EndOfRound());
    }

    private IEnumerator _EndOfRound()
    {
        gm.missionText.text = "Get ready for the next wave...";


        yield return new WaitForSeconds(4);
        gm.bubbleSpeedMultiplier += 0.02f;
        SelectMission();
        updateTextSurvive();
    }
}
