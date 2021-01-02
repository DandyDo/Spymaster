using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timing : MonoBehaviour
{
    public float timer; //timer
    public int minutes; //timer mins
    public int seconds; //timer secs
    public TMP_Text timerText;

    bool playerAllowedToChangeLocation = true; //player can only change location once per day
    int numberOfDays;
    int daysPassed = 0;
    public int minutesPerDay;
    public TMP_Text dayLabel;

    public bool movedToday;

    public Menu endGameMenu;
    // Start is called before the first frame update
    void Start()
    {
        numberOfDays = (int)PlayerPrefs.GetFloat("numberOfDays");
        minutesPerDay = (int)PlayerPrefs.GetFloat("minutesPerDay");
        PlayerPrefs.SetInt("playerAllowedToChangeLocation", 1);//1 = true 0 = false
        dayLabel.text = "Day: 1";
        movedToday = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //getting the time for the timer
        seconds = (int)(timer % 60); //seconds
        minutes = (int)(timer / 60); //minutes

        //check if numbnerOfDays has been reached and end game if so
        if(daysPassed == numberOfDays)
        {
            endGame();
        }

        //allow the player to move again after a day passes
        if (minutes == minutesPerDay)
        {
            PlayerPrefs.SetInt("playerAllowedToChangeLocation", 1);
            movedToday = false;
            timer = 0;
            //seconds = 0;
            //minutes = 0;
            daysPassed++;
            dayLabel.text = "Day: " + (daysPassed + 1).ToString();
        }

        //timer
        if (seconds < 10) //adds a zero if under 10 seconds
        {
            timerText.text = "Time: " + minutes.ToString() + ":0" + seconds.ToString();
        }
        else
        {
            timerText.text = "Time: " + minutes.ToString() + ":" + seconds.ToString();
        }
    }

    public void endGame()
    {
        //Debug.LogError("Game end not implemented!");
        endGameMenu.Open();
    }
}
