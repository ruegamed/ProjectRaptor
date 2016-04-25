using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCommands : MonoBehaviour
{
	public List<GameObject> selectionGroup;
	List<NavMeshAgent> selectionGroupAgents;

	void Start()
	{
		selectionGroup = new List<GameObject>();
		selectionGroupAgents = new List<NavMeshAgent>();
	}

	void Update()
	{
		if(Input.GetMouseButtonUp(0))
		{
			clearSelectionGroup();
		}

		if(Input.GetMouseButtonUp(1))
		{
			moveCommand();
		}
	}

	public void addToSelectionGroup(GameObject newUnit)
	{
		selectionGroup.Add(newUnit);
		selectionGroupAgents.Add(newUnit.GetComponent<NavMeshAgent>());
	}

	private void clearSelectionGroup()
	{
		selectionGroup.Clear();
		selectionGroupAgents.Clear();
	}

	private void moveCommand()
	{
		Ray mousePosition;
		RaycastHit movePoint;

		mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(mousePosition, out movePoint))
		{
			for(int x = 0; x != selectionGroupAgents.Count; x++)
			{
				selectionGroupAgents[x].destination = movePoint.point;
			}
		}
	}
}
