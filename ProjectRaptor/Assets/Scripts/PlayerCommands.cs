using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCommands : MonoBehaviour
{
	public int currentFormation;
	public List<GameObject> selectionGroup;

	List<NavMeshAgent> selectionGroupAgents;
	FormationCalculations formationCalculations;

	void Start()
	{
		currentFormation = 0;
		selectionGroup = new List<GameObject>();
		selectionGroupAgents = new List<NavMeshAgent>();
		formationCalculations = gameObject.GetComponent<FormationCalculations>();
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
			List<Vector3> movePositions;

			movePositions = formationCalculations.getFormationPositions(selectionGroup.Count, calculateGroupPosition(), movePoint.point, currentFormation);

			for(int x = 0; x != selectionGroupAgents.Count; x++)
			{
				selectionGroupAgents[x].destination = movePositions[x];
			}
		}
	}

	private Vector3 calculateGroupPosition()
	{
		Vector3 groupPosition;

		float xAverage;
		float zAverage;

		xAverage = 0;
		zAverage = 0;

		for(int x = 0; x != selectionGroup.Count; x++)
		{
			xAverage += selectionGroup[x].transform.position.x;
			zAverage += selectionGroup[x].transform.position.z;
		}

		xAverage = xAverage / selectionGroup.Count;
		zAverage = zAverage / selectionGroup.Count;

		groupPosition = new Vector3(xAverage, 0, zAverage);

		return groupPosition;
	}
}
