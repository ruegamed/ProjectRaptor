using UnityEngine;
using System.Collections;

//THANKS TO Brent Farris on youtube for this
public class SelectionBox : MonoBehaviour
{
	public Texture2D selectionBox = null;
	public static Rect selection = new Rect(0, 0, 0, 0);
	private Vector3 startClick = -Vector3.one;

	void Update () 
	{
		cameraCheck();
	}

	private void cameraCheck()
	{
		if(Input.GetMouseButtonDown(0))
		{
			startClick = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			startClick = -Vector3.one;
		}

		if(Input.GetMouseButton(0))
		{
			selection = new Rect(startClick.x, InvertMouseY(startClick.y), Input.mousePosition.x - startClick.x, 
				InvertMouseY(Input.mousePosition.y) - InvertMouseY(startClick.y));

			if(selection.width < 0)
			{
				selection.x += selection.width;
				selection.width = -selection.width;
			}
			if(selection.height < 0)
			{
				selection.y += selection.height;
				selection.height = -selection.height;
			}
		}
	}

	private void OnGUI()
	{
		if(startClick != -Vector3.one)
		{
			GUI.color = new Color(1, 1, 1, 0.3F);
			GUI.DrawTexture(selection, selectionBox);
		}
	}

	public static float InvertMouseY(float y)
	{
		return Screen.height - y;
	}
}
