using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLoseConditions : MonoBehaviour
{
    public MissionController MissionControl;

    public int team1score = 0;
    public int team2score = 0;
    public int winningScore = 500;
    public TMP_Text Team1Scorelabel = null;
    public TMP_Text Team2Scorelabel = null;
    [HideInInspector] public bool team1won = false;
    [HideInInspector] public bool team2won = false;


    public List<Missions> MissionsList = new List<Missions>();
    public List<TMP_Text> MissionListOnScreen = new List<TMP_Text>();
    public void diplayMissions()
    {

        int i = 0;
        foreach (TMP_Text MissionOnScreen in MissionListOnScreen)
        {
            if (i < MissionsList.Count)
            {
                MissionOnScreen.text = "Get to " + MissionsList[i].locationToGetTo.name + " - " + MissionsList[i].pointValueForCompletion + " points";
            }
            
            i++;
        }
    }

    public int checkMissionCompletion() //returns point value to increase score by
    {
        int sumOfPointsToBeAddedToScore = 0;
        for (int i = 0; i < MissionListOnScreen.Count; i++)
        {
            MissionListOnScreen[i].text = "";
            if (i < MissionsList.Count)
            {
                if (MissionsList[i].completed)
                {
                    sumOfPointsToBeAddedToScore += MissionsList[i].pointValueForCompletion;
                    MissionsList.RemoveAt(i);
                }
            }
            diplayMissions();
        }
        //for some reaoson the value is being reset to 0 before it returns
        return sumOfPointsToBeAddedToScore;
    }

    double UpdateFrequency;
    private void Start()
    {
        diplayMissions();
        
    }

    double timer;
    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer -= 1;
            increaseTeam1Score(checkMissionCompletion()); //increasing player score based on completed missions 
        }
        
       
    }


    //trying to keep the information from this script available in the next scene
    public static WinLoseConditions WL;
    void Awake()
    {
        if (WL != null)
        {
            GameObject.Destroy(WL);
        }
        else
        {
            WL = this;
        }
        DontDestroyOnLoad(this); 
    }

    //increasing scores
    public void increaseTeam1Score(int amountToIncreaseBy)
    {
        team1score += amountToIncreaseBy;
        Team1Scorelabel.text = "Your score: " + team1score.ToString();
        if (team1score >= winningScore)
        {
            //load winning scene
            //would like to make sure this shows who won the game
            team1won = true;
            SceneManager.LoadScene("WinningScene");
        }
    }

    public void increaseTeam2Score(int amountToIncreaseBy)
    {
        team2score += amountToIncreaseBy;
        Team2Scorelabel.text = "Their score: " + team2score.ToString();
        if (team2score >= winningScore)
        {
            //load winning scene
            team2won = true;
            SceneManager.LoadScene("LosingScene");
        }
    }
    // Start is called before the first frame update


    
    
    

}
