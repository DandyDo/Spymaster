using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GPSBypass : MonoBehaviour
{
    public TMP_Text GPSLocationDisplay;


    public void changeLocation(string location)
    {
        Debug.Log("playerAllowedToChangeLocation = " + PlayerPrefs.GetInt("playerAllowedToChangeLocation"));
        if (PlayerPrefs.GetInt("playerAllowedToChangeLocation") == 1)//1 = true 0 = false
        {
            GPSLocationDisplay.text = " GPS Location: " + location;
            //PlayerPrefs.SetInt("playerAllowedToChangeLocation", 0);//1 = true 0 = false
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
