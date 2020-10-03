namespace Mapbox.Examples
{
	using UnityEngine;

	public class CameraBillboard : MonoBehaviour
	{
		public Camera _camera;

		public void Start()
		{
			// There are better ways, but for now I'll use this
			_camera = GameObject.Find("GpsCamera").GetComponent<Camera>();
		}

		void Update()
		{
			transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
		}
	}
}