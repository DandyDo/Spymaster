using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I have collided with the building");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("I am still in the building");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("I have exited the building");
    }
}
