using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject panel;
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
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            _camera.gameObject.SetActive(false);
            _camera.enabled = false;
            panel.SetActive(false);
        }
    }
}
