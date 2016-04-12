using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{	
	void Update () 
	{
		float cameraPanX;
		float cameraPanZ;
		float cameraRotate;
		Vector3 cameraRotation;

		cameraPanX = Input.GetAxis("CameraPanHorizontal");
		cameraPanZ = Input.GetAxis("CameraPanVertical");
		cameraRotate = Input.GetAxis("CameraRotate");

		cameraRotation = gameObject.transform.rotation.eulerAngles;
		cameraRotation.y += cameraRotate;

		gameObject.transform.position += gameObject.transform.forward * cameraPanZ;
		gameObject.transform.position += gameObject.transform.right * cameraPanX;
		gameObject.transform.rotation = Quaternion.Euler(cameraRotation);
	}
}
