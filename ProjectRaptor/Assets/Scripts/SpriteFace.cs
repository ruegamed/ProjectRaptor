using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteFace : MonoBehaviour 
{
	public List<Sprite> spriteList;

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
		unitScript = parent.GetComponent<UnitScript>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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

		faceSprite();
	}

	private void faceSprite()
	{
		float directionNumber;

		directionNumber = calculateYDifference();

		if(directionNumber > 22.5F && directionNumber < 67.5F)
		{
			spriteRenderer.sprite = spriteList[7];
		}
		else if(directionNumber > 67.5F && directionNumber < 112.5F)
		{
			spriteRenderer.sprite = spriteList[6];
		}
		else if(directionNumber > 112.5F && directionNumber < 157.5F)
		{
			spriteRenderer.sprite = spriteList[5];
		}
		else if(directionNumber > 157.5F && directionNumber < 202.5F)
		{
			spriteRenderer.sprite = spriteList[4];
		}
		else if(directionNumber > 202.5F && directionNumber < 247.5F)
		{
			spriteRenderer.sprite = spriteList[3];
		}
		else if(directionNumber > 247.5F && directionNumber < 292.5F)
		{
			spriteRenderer.sprite = spriteList[2];
		}
		else if(directionNumber > 292.5F && directionNumber < 337.5F)
		{
			spriteRenderer.sprite = spriteList[1];
		}
		else// if(directionNumber < 22.5F || directionNumber > 337.5F)
		{
			spriteRenderer.sprite = spriteList[0];
		}
	}

	private float calculateYDifference()
	{
		float yUnitFacingDirection;
		float yCamera;
		float yDifference;

		yUnitFacingDirection = unitScript.facingDirection.y;
		yCamera = gameObject.transform.eulerAngles.y;

		if(yUnitFacingDirection > yCamera)
		{
			yDifference = yCamera - yUnitFacingDirection + 360;
		}
		else
		{
			yDifference = yCamera - yUnitFacingDirection;
		}

		//Debug.Log(yDifference);

		return yDifference;
	}
}
