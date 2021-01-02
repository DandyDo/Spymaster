using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationInNode : MonoBehaviour
{
    public string name;
    public List<GameObject> LocationsYouCanGoToFromCurrentLocation = new List<GameObject>();

    //LocationInNode thisLocation;
    // Start is called before the first frame update
    void Start()
    {
        //thisLocation = this;
        //name = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
