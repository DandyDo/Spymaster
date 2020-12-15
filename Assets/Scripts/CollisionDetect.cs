using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetect : MonoBehaviour
{
    public GameObject gpsLocation;
    TextMeshProUGUI gpsLocationText;
    string onEnterBuilding;
    bool hubFound = false;

    private void Start()
    {
        gpsLocationText = gpsLocation.GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hub")
        {
            onEnterBuilding = other.gameObject.name;

            gpsLocationText.text = " GPS Location: " + onEnterBuilding;
        }

        //Debug.Log("I have collided with " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hub")
        {

        }

        //Debug.Log("I have exited " + other.gameObject.name);
    }

    // In case a building did not get a name during initialization
    private void OnTriggerStay(Collider other)
    {
        if (!hubFound && other.tag == "Hub")
        {
            onEnterBuilding = other.gameObject.name;

            gpsLocationText.text = " GPS Location: " + onEnterBuilding;

            hubFound = true;
        }
    }
}
