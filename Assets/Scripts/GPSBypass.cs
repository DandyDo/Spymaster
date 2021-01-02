using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GPSBypass : MonoBehaviour
{
    public TMP_Text GPSLocationDisplay;
    public Timing timerClass;
    public void changeLocation(string location)
    {
        Debug.Log("movedToday: " + timerClass.movedToday);
        //Debug.Log("playerAllowedToChangeLocation = " + PlayerPrefs.GetInt("playerAllowedToChangeLocation"));
        if (timerClass.movedToday == false)
        {
            GPSLocationDisplay.text = " GPS Location: " + location;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
