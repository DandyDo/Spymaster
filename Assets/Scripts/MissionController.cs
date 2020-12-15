using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionController : MonoBehaviour
{
     WinLoseConditions WinLoss;
    public List<Missions> MissionsList = new List<Missions>();
    public List<TMP_Text> MissionListOnScreen = new List<TMP_Text>();
    // Start is called before the first frame update
    void Start()
    {
        //this is now being don in WinLossConditions.cs
        //diplayMissions();
    }

    public void diplayMissions()
    {
        
        int i = 0;
        foreach (TMP_Text MissionOnScreen in MissionListOnScreen)
        {
            MissionOnScreen.text = "Get to " + MissionsList[i].locationToGetTo.name + " - " + MissionsList[i].pointValueForCompletion + " points";
            i++;
        }
    }

    public int checkMissionCompletion() //returns point value to increase score by
    {
        int sumOfPointsToBeAddedToScore = 0;
        int i = 0;
        foreach (TMP_Text MissionOnScreen in MissionListOnScreen)
        {
            if (MissionsList[i].completed && i < MissionsList.Count)
            {
                sumOfPointsToBeAddedToScore += MissionsList[i].pointValueForCompletion;
                MissionsList.RemoveAt(i);
                MissionListOnScreen[i].text = "";
                diplayMissions();
            }
            i++;
        }
       Debug.Log("Points to be added to score" + sumOfPointsToBeAddedToScore);
        return sumOfPointsToBeAddedToScore;
    }

    // Update is called once per frame
    void Update()
    {
        //this is now being don in WinLossConditions.cs
        //checkMissionCompletion();

    }
}
