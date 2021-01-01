using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeManager : MonoBehaviour
{
    public List<Node> Nodes = new List<Node>();
    public TMP_Text locationDisplay;
    string GPSLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        GPSLocation = locationDisplay.text.Substring(15);
    }

    // Update is called once per frame
    void Update()
    {
        GPSLocation = locationDisplay.text.Substring(15);
        //need to load the menu for the current node
        foreach (Node node in Nodes)
        {
            if (node.name == GPSLocation)
            {
                node.gameObject.SetActive(true);
            }
            else
            {
                node.gameObject.SetActive(false);
            }
        }
    }
}
