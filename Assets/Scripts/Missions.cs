using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//simple mission for now. Get to Minsk to get points
public class Missions : MonoBehaviour
{
    public int pointValueForCompletion;
    public bool completed = false;
    public GameObject Player;

    public List<GameObject> locations = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {

    }
}
