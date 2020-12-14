using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLoseConditions : MonoBehaviour
{
    

    [HideInInspector] int team1score = 0;
    [HideInInspector] int team2score = 0;
    public int winningScore = 500;
    public TMP_Text Team1Scorelabel = null;
    public TMP_Text Team2Scorelabel = null;
    [HideInInspector] public bool team1won = false;
    [HideInInspector] public bool team2won = false;

    //mission to minsk
    public TMP_Text PlayerLocationText;
    string PlayerLocation;
    bool minskMissionComplete = false;
    bool moscowMissionComplete = false;
    // Update is called once per frame
    void Update()
    {
        PlayerLocation = PlayerLocationText.text.Substring(15);
        if (PlayerLocation == "Minsk" && minskMissionComplete == false)
        {
            minskMissionComplete = true;
            increaseTeam1Score(250);
        }
        if (PlayerLocation == "Moscow" && moscowMissionComplete == false)
        {
            moscowMissionComplete = true;
            increaseTeam1Score(250);
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
