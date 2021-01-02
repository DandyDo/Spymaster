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
    public Timing timerClass;


    // Start is called before the first frame update
    void Start()
    {
        timerClass.movedToday = false;
        locationTextFromGPS = GpsLcoationText.text.Substring(15);
        MapLocationText.text = " Map Location: " + locationTextFromGPS;

        float step = playerIconMovementSpeed * Time.deltaTime;
        foreach (GameObject location in locations)
        {
            if (location.name == locationTextFromGPS)//player can only change location once per day
            {
                //move player to initial location instantly
                PlayerOnMap.transform.position = location.transform.position;

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
            if (location.name == locationTextFromGPS && timerClass.movedToday == false &&
                PlayerOnMap.transform.position != location.transform.position)//player can only change location once per day
            {
                //PlayerOnMap.transform.position = location.transform.position;
                

                //move icon over time instead of instantly
                PlayerOnMap.transform.position = Vector3.MoveTowards(PlayerOnMap.transform.position, location.transform.position, step);
                //Let the player icon move until it gets close enough to the location
                if (Vector3.Distance(PlayerOnMap.transform.position, location.transform.position) == 0)
                {
                    timerClass.movedToday = true;

                }
            }
        }
    }
}
