using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{	
	GameObject mainCamera;

	void Start()
	{
		mainCamera = gameObject.transform.GetChild(0).gameObject;
	}

	void Update()
	{
		float cameraPanX;
		float cameraPanZ;
		float cameraZoom;
		float cameraRotate;
		Vector3 cameraRotation;

		cameraPanX = Input.GetAxis("CameraPanHorizontal");
		cameraPanZ = Input.GetAxis("CameraPanVertical");
		cameraZoom = Input.GetAxis("CameraZoom");
		cameraRotate = Input.GetAxis("CameraRotate");

		cameraRotation = gameObject.transform.rotation.eulerAngles;
		cameraRotation.y += cameraRotate;

		gameObject.transform.position += gameObject.transform.forward * cameraPanZ;
		gameObject.transform.position += gameObject.transform.right * cameraPanX;
		mainCamera.gameObject.transform.position += mainCamera.gameObject.transform.forward * cameraZoom;
		gameObject.transform.rotation = Quaternion.Euler(cameraRotation);
	}
}
