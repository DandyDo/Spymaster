using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform player;
    public Vector3 camOffset = new Vector3(0, 60, -60);
    public float zoomOutMin = 20;
    public float zoomOutMax = 80;

    private void Start()
    {
        // Position the main camera at the player's position with offset
        transform.position = player.position + camOffset;
    }

    private void LateUpdate()
    {
        //Follow the player's position
        transform.position = player.position + camOffset;

        // Rotate the camera around the player with one touch swipe
        if (Input.touchCount == 1)
        {
            Touch touchZero = Input.GetTouch(0);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;

            float touchZeroCurr = touchZero.position.x - touchZeroPrevPos.x;

            transform.RotateAround(player.position, Vector3.up, touchZeroCurr * 0.06f);
            // assign the new value of the player location to the camera offset
            camOffset = transform.position - player.position;
        }

        // Pinch-zoom (2-touches) the camera's field of view
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.05f);
        }
    }

    void zoom(float increment)
    {
        // Change the field of view of camera based on the player's touch
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - increment, zoomOutMin, zoomOutMax);      
    }
}
