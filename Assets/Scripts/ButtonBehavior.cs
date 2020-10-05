using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject panel;
    Camera _camera;
    public GameObject gpsMap;

    public void Start()
    {
        _camera = GameObject.Find("GpsCamera").GetComponent<Camera>();
    }

    public void DisplayGps()
    {
        if (!panel.activeSelf)
        {
            GetComponent<Image>().color = Color.green;
            gpsMap.SetActive(true);
            panel.SetActive(true);
            _camera.gameObject.SetActive(true);
            _camera.enabled = true;
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            gpsMap.SetActive(false);
            _camera.gameObject.SetActive(false);
            _camera.enabled = false;
            panel.SetActive(false);
        }
    }
}
