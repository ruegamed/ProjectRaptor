using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class SpriteFace : MonoBehaviour 
{
	void Start()
	{
		
	}

	void Update () 
	{
		Vector3 cameraPosition;
		Quaternion currentRotation;
		float lockX = 0;

		cameraPosition = GameObject.FindGameObjectWithTag("MainCamera").transform.position;

		this.gameObject.transform.LookAt(cameraPosition);
		currentRotation = this.gameObject.transform.rotation;
		currentRotation.x = lockX;
		currentRotation.z = lockX;

		this.gameObject.transform.localRotation = currentRotation;
	}
}
