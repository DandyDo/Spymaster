using UnityEngine;

public class PanCamera : MonoBehaviour
{
    public Camera cam;
    public float zoomOutMin = 45;
    public float zoomOutMax = 60;
    public float speed = 0.01F;

    private void Start()
    {
        transform.position = Vector3.zero;
    }

    private void LateUpdate()
    {
        // Pan around the map
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5f, 5f),
                                        Mathf.Clamp(transform.position.y, -5f, 5f), 0);
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
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5f, 5f),
                                        Mathf.Clamp(transform.position.y, -5f, 5f), 0);
        }
    }

    void zoom(float increment)
    {
        // Change the field of view of camera based on the player's touch
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - increment, zoomOutMin, zoomOutMax);
    }
}
