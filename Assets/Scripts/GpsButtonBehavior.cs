using UnityEngine;
using UnityEngine.UI;

public class GpsButtonBehavior : MonoBehaviour
{
    public GameObject panel;
    public PanCamera MainCameraScript;  // lazy way to disable/enable the camera script?
    Camera _camera;

    public void Start()
    {
        _camera = GameObject.Find("GpsCamera").GetComponent<Camera>();
    }

    public void DisplayGps()
    {
        if (!panel.activeSelf)
        {
            GetComponent<Image>().color = Color.green;
            panel.SetActive(true);
            _camera.gameObject.SetActive(true);
            _camera.enabled = true;
            MainCameraScript.enabled = false;
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            _camera.gameObject.SetActive(false);
            _camera.enabled = false;
            MainCameraScript.enabled = true;
            panel.SetActive(false);
        }
    }
}
