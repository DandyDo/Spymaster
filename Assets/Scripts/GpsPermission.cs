using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class GpsPermission : MonoBehaviour
{
    void Start()
    {
        // This is not the best way to ask for permission. This is just a test.
        if (Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Debug.Log("Location Autoherized"); // The user authorized use of the FineLocation.
        }
        else
        {
            // We do not have permission to use the FineLocation.
            // Ask for permission or proceed without the functionality enabled.
            Permission.RequestUserPermission(Permission.FineLocation);
        }
    }
}
