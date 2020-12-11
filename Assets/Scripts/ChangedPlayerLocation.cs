using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
//This script is supposed to display the characters location on the map based on the gps location
//CURRENT BUG: player sprite disappears when i press play. It seems to be going where I want it, but it's hard to tell since you can't see it.
public class ChangedPlayerLocation : MonoBehaviour
{
    public TMP_Text GpsLcoationText;
    string locationTextFromGPS;
    public TMP_Text MapLocationText;
    public GameObject PlayerOnMap;

    public List<GameObject> locations = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        locationTextFromGPS = GpsLcoationText.text.Substring(15);

    }

    // Update is called once per frame
    void Update()
    {
        locationTextFromGPS = GpsLcoationText.text.Substring(15);
        MapLocationText.text = " Map Location: " + locationTextFromGPS;

        foreach (GameObject location in locations)
        {
            if (location.name == locationTextFromGPS)
            {
                PlayerOnMap.transform.position = location.transform.position;
            }
        }
    }
}
