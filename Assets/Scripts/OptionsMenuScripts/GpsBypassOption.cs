using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpsBypassOption : MonoBehaviour
{


    public void turnOnGPSBypass()
    {
        PlayerPrefs.SetString("GPSBypassOption", "on");
    }

    public void turnOffGPSBypass()
    {
        PlayerPrefs.SetString("GPSBypassOption", "off");
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetString("GPSBypassOption");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
