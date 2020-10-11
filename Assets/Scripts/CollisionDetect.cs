using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    #if (UNITY_EDITOR)
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I have collided with " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("I am still in " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("I have exited " + other.gameObject.name);
    }
    #endif
}
