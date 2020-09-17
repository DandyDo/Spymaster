using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using UnityEngine;
using Mapbox.Map;
using Mapbox.Unity.Map;
using System.Linq;

public class SetGameLocation : MonoBehaviour
{
    List<GameObject> buildings = new List<GameObject>();
    List<Collider> colliders = new List<Collider>();
    public Transform player;
    public float playerRadius = 30;
    public float buildingRadius = 20; // Do not go below 9. Causes Unity to freeze for no reason. (find fix when you have time)

    // Bit shift the index of the layer 8 (player) to get a bit mask
    int layerMask = 1 << 8;

    // Start is called before the first frame update
    void Start()
    {
        // invert bit mask to ignore layer 8 specifically.
        layerMask = ~layerMask;

        StartCoroutine(GetClosestBuildings());
    }

    // Wait for n seconds before addings buildings within radius of player to a list
    IEnumerator GetClosestBuildings()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("waited 3 seconds");

        // search for the closest buildings to the player
        colliders = Physics.OverlapSphere(player.transform.position, playerRadius, layerMask).ToList();

        foreach (Collider collider in colliders)
        {
            buildings.Add(collider.gameObject);
        }

        Debug.Log("There are " + buildings.Count + " buildings in the list. GetClosestBuildings");

        colliders.Clear();

        yield return FetchBuildings();
    }

    // set the list with all the buildings after GetClosestBuildings()
    IEnumerator FetchBuildings()
    {
        while (buildings.Count < 10)
        {
            List<GameObject> tempBuildings = new List<GameObject>();

            foreach (GameObject building in buildings)
            {
                if (Physics.CheckSphere(building.transform.position, buildingRadius, layerMask)) // Check if there are nearby building close to the curr building
                {
                    colliders = Physics.OverlapSphere(building.transform.position, buildingRadius, layerMask).ToList();
                    foreach (Collider collider in colliders)
                    {
                        if (!buildings.Contains(collider.gameObject))
                        {
                            if (tempBuildings.Count < 10 - buildings.Count) // check if buildings found so far are less than 10
                            {
                                tempBuildings.Add(collider.gameObject);
                            }
                            else
                            {
                                break;
                            }

                        }
                        Debug.Log("There are " + tempBuildings.Count + " buildings in the temp list.");
                    }

                    colliders.Clear();
                }
            }

            buildings.AddRange(tempBuildings);
            Debug.Log("There are " + buildings.Count + " buildings in the list.");
        }

        yield break;
    }
}
