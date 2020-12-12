using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    public WinLoseConditions WinLoss;
    // Start is called before the first frame update
    void Start()
    {
       // Scoring.current.onMissionCompleted += Current_onMissionCompleted;
    }

    private void Current_onMissionCompleted()
    {
        WinLoss.increaseTeam1Score(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
