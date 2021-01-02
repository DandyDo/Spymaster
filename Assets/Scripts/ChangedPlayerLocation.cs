using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
//This script is supposed to display the characters location on the map based on the gps location

public class ChangedPlayerLocation : MonoBehaviour
{
    public TMP_Text GpsLcoationText;
    string locationTextFromGPS;
    public TMP_Text MapLocationText;
    public GameObject PlayerOnMap;
    public float playerIconMovementSpeed;

    public List<GameObject> locations = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("playerAllowedToChangeLocation", 1);//1 = true 0 = false
        locationTextFromGPS = GpsLcoationText.text.Substring(15);
        MapLocationText.text = " Map Location: " + locationTextFromGPS;

        float step = playerIconMovementSpeed * Time.deltaTime;
        foreach (GameObject location in locations)
        {
            if (location.name == locationTextFromGPS )//player can only change location once per day
            {
                //move icon over time instead of instantly
                PlayerOnMap.transform.position = Vector3.MoveTowards(PlayerOnMap.transform.position, location.transform.position, step);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        locationTextFromGPS = GpsLcoationText.text.Substring(15);
        MapLocationText.text = " Map Location: " + locationTextFromGPS;

        float step = playerIconMovementSpeed * Time.deltaTime;

        foreach (GameObject location in locations)
        {
            if (location.name == locationTextFromGPS  && 
                PlayerPrefs.GetInt("playerAllowedToChangeLocation") == 1)//player can only change location once per day
            {
                //move icon over time instead of instantly
                PlayerOnMap.transform.position = Vector3.MoveTowards(PlayerOnMap.transform.position, location.transform.position, step);
                PlayerPrefs.SetInt("playerAllowedToChangeLocation", 0);//1 = true 0 = false
            }
        }
    }
}
