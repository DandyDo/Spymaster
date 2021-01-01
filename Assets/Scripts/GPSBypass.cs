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
        GPSLocationDisplay.text = " GPS Location: " + location;
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
