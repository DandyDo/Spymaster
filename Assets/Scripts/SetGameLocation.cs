using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using UnityEngine;
using Mapbox.Map;
using Mapbox.Unity.Map;

public class SetGameLocation : MonoBehaviour
{
    List<GameObject> buildings = new List<GameObject>();
    public Transform player;
    public float radius = 20;

    // Bit shift the index of the layer 8 (player) to get a bit mask
    int layerMask = 1 << 8;

    // Start is called before the first frame update
    void Start()
    {
        // invert bit mask to ignore layer 8 specifically.
        layerMask = ~layerMask;

        StartCoroutine(GetClosestBuildings());

        Debug.Log("There are " + buildings.Count + " buildings in the list.");    
    }

    // Wait for n seconds before addings buildings within radius of player to a list
    IEnumerator GetClosestBuildings()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("waited 3 seconds");

        // search for the closest buildings to the player
        Collider[] colliders = Physics.OverlapSphere(player.position, radius, layerMask);
        
        foreach (Collider collider in colliders)
        {
            buildings.Add(collider.gameObject);
        }
        Debug.Log("There are " + buildings.Count + " buildings in the list.");

        yield return SetBuildings();
    }

    // set the list with all the buildings after GetClosestBuildings()
    IEnumerator SetBuildings()
    {
        

        yield break;
    }
}
