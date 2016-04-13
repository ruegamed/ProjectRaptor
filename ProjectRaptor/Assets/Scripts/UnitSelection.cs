using UnityEngine;
using System.Collections;

//THANKS TO Brent Farris on youtube for this
public class UnitSelection : MonoBehaviour 
{
	public bool selected = false;

	void Update () 
	{
		if(Input.GetMouseButtonUp(0))
		{
			Vector3 cameraPosition = Camera.main.WorldToScreenPoint(transform.position);
			cameraPosition.y = SelectionBox.InvertMouseY(cameraPosition.y);
			selected = SelectionBox.selection.Contains(cameraPosition);
			Debug.Log(selected);
		}

		if(selected)
		{
			SpriteRenderer pic = gameObject.GetComponent<SpriteRenderer>();
			Color newColor = new Color(0, 0, 0, 1);

			pic.color = newColor;
		}
		else
		{
			SpriteRenderer pic = gameObject.GetComponent<SpriteRenderer>();
			Color newColor = new Color(1, 1, 1, 1);

			pic.color = newColor;
		}
	}
}
