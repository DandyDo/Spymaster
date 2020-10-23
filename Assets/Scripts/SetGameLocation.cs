using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script fetches the buildings generated from Mapbox, stores them in a list,
/// modifies them, then finally sets them to the game Hub objects.
/// </summary>
public class SetGameLocation : MonoBehaviour
{
    List<GameObject> buildings = new List<GameObject>();    
    List<Collider> colliders = new List<Collider>();

    public Transform hubHolder;

    public Transform player;
    public float playerRadius = 30;
    public float buildingRadius = 20;
    public GameObject prefab;
    public Color[] colors;

    // Bit shift the index of the GpsPlayer and Default to get a bit mask
    int layerMask = (1 << 8 | 1 << 0);

    // Start is called before the first frame update
    void Start()
    {
        // Invert bit mask to ignore layer 8 (player) specifically.
        layerMask = ~layerMask;     
    }

    void Update()
    {
        if (Physics.CheckSphere(player.transform.position, playerRadius, layerMask))
        {
            Invoke("GetClosestBuildings", 3.0f); ;

            enabled = false; // Turn off script once done.
        }
    }

    // Wait for n seconds before addings buildings within radius of player to a list
    void GetClosestBuildings()
    {
        // Search for the closest buildings to the player
        colliders = Physics.OverlapSphere(player.transform.position, playerRadius, layerMask).ToList();

        colliders.Sort(DistanceToPlayer);

        foreach (Collider collider in colliders)
        {
            if (buildings.Count < 10)
            {
                buildings.Add(collider.gameObject);
            }
            else
            {
                break;
            }
        }

        colliders.Clear();

        Invoke("FetchBuildings", 0f);
    }

    // Fetch the rest of the buildings if the list wasn't filled after GetClosestBuildings()
    void FetchBuildings()
    {
        int i = buildings.Count;
        while (buildings.Count < 10 && i < 10)
        {
            List<GameObject> tempBuildings = new List<GameObject>();

            foreach (GameObject building in buildings)
            {
                // Check if there are nearby building close to the curr building
                if (Physics.CheckSphere(building.transform.position, buildingRadius, layerMask))
                {
                    colliders = Physics.OverlapSphere(building.transform.position, buildingRadius, layerMask).ToList();

                    foreach (Collider collider in colliders)
                    {
                        if (!buildings.Contains(collider.gameObject))
                        {
                            // check if buildings found so far are less than 10
                            if (tempBuildings.Count < 10 - buildings.Count)
                            {
                                tempBuildings.Add(collider.gameObject);
                            }
                        }
                    }

                    colliders.Clear();
                }
            }

            i++;

            buildings.AddRange(tempBuildings);
            // Debug.Log("There are " + buildings.Count + " buildings in the list.");
        }

        Invoke("EditBuildings", 0f);
    }

    // Modify the selected buildings. (Sort buildings by distance from player, buildings' names, and colors)
    void EditBuildings()
    {
        // Sort the returned compared result from the function
        buildings.Sort(DistanceToPlayer);

        // Give a Tag for each building
        foreach (GameObject building in buildings)
        {
            building.tag = "Hub";
        }

        Transform[] hubs = new Transform[hubHolder.childCount];
        int x = 0;

        foreach (Transform hub in hubHolder)
        {
            hubs[x] = hub;
            x++;
        }

        // Instantiate a prefarb (Poi Marker) on each buildings in the list
        for (int i = 0; i < buildings.Count; i++)
        {
            var newPrefab = Instantiate(prefab, buildings[i].transform.position, Quaternion.identity, buildings[i].transform);

            newPrefab.GetComponentInChildren<Text>().text = buildings[i].name;

            var buildingRenderer = buildings[i].GetComponent<Renderer>().materials;
            var newPrefabRenderer = newPrefab.GetComponentInChildren<SpriteRenderer>();

            foreach (Material material in buildingRenderer)
            {
                material.SetColor("_Color", colors[i]);
            }
            //buildingRenderer.material.SetColor("_Color", colors[i]);      // for top-side (roof) color only. Remove the loop in this case.
            newPrefabRenderer.material.SetColor("_Color", colors[i]);

            if (hubs[i] != null)
            {
                buildings[i].name = hubs[i].name;
                newPrefab.GetComponentInChildren<Text>().text = hubs[i].name;

                var hubRenderer = hubs[i].GetComponent<SpriteRenderer>();
                hubRenderer.color = colors[i];
            }
        }
    }

    int DistanceToPlayer(GameObject a, GameObject b)
    {
        // Find each sqrMagnitude of each object from player and compare
        float x = (a.transform.position - player.position).sqrMagnitude;
        float y = (b.transform.position - player.position).sqrMagnitude;

        return x.CompareTo(y);
    }

    int DistanceToPlayer(Collider a, Collider b)
    {
        // Find each sqrMagnitude of each object from player and compare
        float x = (a.transform.position - player.position).sqrMagnitude;
        float y = (b.transform.position - player.position).sqrMagnitude;

        return x.CompareTo(y);
    }
}
