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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //getting the time for the timer
        seconds = (int)(timer % 60); //seconds
        minutes = (int)(timer / 60); //minutese

        if (seconds < 10) //adds a zero if under 10 seconds
        {
            timerText.text = "Time: " + minutes.ToString() + ":0" + seconds.ToString();
        }
        else
        {
            timerText.text = "Time: " + minutes.ToString() + ":" + seconds.ToString();
        }
    }
}
