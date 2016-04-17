using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//THANKS TO Brent Farris on youtube for this
public class UnitSelection : MonoBehaviour 
{
	public bool selected = false;
	public GameObject selectionBoxParent;

	List<GameObject> selectionBox;
	PlayerCommands pc;

	void Start()
	{
		selectionBox = new List<GameObject>();

		for(int x = 0; x != selectionBoxParent.transform.childCount; x++)
		{
			selectionBox.Add(selectionBoxParent.transform.GetChild(x).gameObject);
		}

		selectionBox.Add(gameObject);

		pc = GameObject.Find("PlayerController").GetComponent<PlayerCommands>();
	}

	void Update() 
	{
		if(Input.GetMouseButtonUp(0) && isOnCamera())
		{
			selected = isSelected();
		}

		if(selected)
		{
			SpriteRenderer pic = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
			Color newColor = new Color(0.5F, 0.5F, 0.5F, 1);

			pic.color = newColor;
		}
		else
		{
			SpriteRenderer pic = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
			Color newColor = new Color(1, 1, 1, 1);

			pic.color = newColor;
		}
	}

	private bool isSelected()
	{
		if(isBoxSelected())
		{
			return true;
		}
		else if(isClickSelected())
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private bool isBoxSelected()
	{
		Vector3 selectionPointPosition;

		for(int x = 0; x != selectionBox.Count; x++)
		{
			selectionPointPosition = Camera.main.WorldToScreenPoint(selectionBox[x].transform.position);
			selectionPointPosition.y = SelectionBox.InvertMouseY(selectionPointPosition.y);

			if(SelectionBox.selection.Contains(selectionPointPosition))
			{
				addToSelectionGroup();

				return true;
			}
		}

		return false;
	}

	private bool isClickSelected()
	{
		Ray ray;
		RaycastHit hit;

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit))
		{
			if(hit.transform.gameObject.Equals(gameObject))
			{
				addToSelectionGroup();

				return true;
			}
		}

		return false;
	}

	private bool isOnCamera()
	{
		Vector3 position;

		position = Camera.main.WorldToViewportPoint(gameObject.transform.position);

		if(position.x >= 0 && position.y >= 0 && position.x <= 1 && position.y <= 1)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private void addToSelectionGroup()
	{
		if(!isInSelectionGroup())
		{
			pc.addToSelectionGroup(gameObject);
		}
	}

	private bool isInSelectionGroup()
	{
		if(pc.selectionGroup.Contains(gameObject))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
