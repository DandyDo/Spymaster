using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using UnityEngine;

public class SetGameLocation : MonoBehaviour
{

    private int hubCount = 10;

    // Start is called before the first frame update
    void Start()
    {
       // GameObject[] hubs = new GameObject[hubCount];

        StartCoroutine(GetHubLocation());


        /*//manually builds an array of Hubs
        for (int i = 0; i < hubCount; i++)
        {
            hubs[i] = GameObject.FindWithTag("Hub" + i);
        }
        for (int i = 0; i < hubCount; i++)
        {
            Debug.Log(hubs[i].name);
        }*/
    }

    // Wait for n seconds (depends on how long it takes to load the POI. There has to be a better way to do this) before fetching the POI locations.
    IEnumerator GetHubLocation()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("waited 5 seconds");

        GameObject[] hubs = GameObject.FindGameObjectsWithTag("Hub");

        for (int i = 0; i < hubCount; i++)
        {
            Debug.Log("This is " + hubs[i].name + hubs[i].transform.position);
        }
    }

}
