using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteFaceSimple : MonoBehaviour 
{
	private Camera mainCamera;
	private BoxCollider selectionCollider;
	private GameObject parent;
	private UnitScript unitScript;
	private SpriteRenderer spriteRenderer;

	private const float lockX = 0;
	private const float lockZ = 0;

	void Start()
	{
		mainCamera = Camera.main;
		parent = gameObject.transform.parent.gameObject;
		selectionCollider = parent.GetComponent<BoxCollider>();
	}

	void Update() 
	{
		Vector3 cameraPosition;
		Quaternion currentRotation;
		float lockX = 0;

		cameraPosition = mainCamera.transform.position;

		this.gameObject.transform.LookAt(cameraPosition);
		currentRotation = this.gameObject.transform.rotation;
		currentRotation.x = lockX;
		currentRotation.z = lockZ;

		gameObject.transform.rotation = currentRotation;
		selectionCollider.transform.rotation = currentRotation;
	}
}
