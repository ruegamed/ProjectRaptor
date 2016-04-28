using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FormationCalculations : MonoBehaviour
{
	public LineData ShortLineData;
	public LineData LongLineData;
	public LineData LooseLineData;

	void Start()
	{
	
	}

	public List<Vector3> getFormationPositions(int groupSize, Vector3 groupLocation, Vector3 moveLocation, int formation)
	{
		if(formation == 0)
		{
			//Debug.Log("Short Line");
			return getLinePositions(groupSize, groupLocation, moveLocation, ShortLineData);
		}
		else if(formation == 1)
		{
			//Debug.Log("Long Line");
			return getLinePositions(groupSize, groupLocation, moveLocation, LongLineData);
		}
		else// if(formation == 2)
		{
			//Debug.Log("Loose Line");
			return getLinePositions(groupSize, groupLocation, moveLocation, LooseLineData);
		}
	}

	List<Vector3> getLinePositions(int groupSize, Vector3 groupLocation, Vector3 moveLocation, LineData lineData)
	{
		List<Vector3> movePositions;

		GameObject moveReferenceObject;
		int unitsRemaining;

		int unitsThisLine;
		float lengthOfLine;
		bool cont;

		Vector3 lastPosition;

		movePositions = new List<Vector3>();

		moveReferenceObject = createMoveReferenceObject(groupLocation, moveLocation);
		unitsRemaining = groupSize;

		cont = true;

		while(cont)
		{
			if(unitsRemaining > lineData.unitsPerLine)
			{
				unitsThisLine = lineData.unitsPerLine;
				unitsRemaining -= lineData.unitsPerLine;
			}
			else
			{
				unitsThisLine = unitsRemaining;
				unitsRemaining = 0;
				cont = false;
			}

			lengthOfLine = (unitsThisLine - 1) * lineData.horizontalSpacing;

			lastPosition = moveReferenceObject.transform.position - moveReferenceObject.transform.right * (0.5F * lengthOfLine);

			for(int x = 0; x != unitsThisLine; x++)
			{
				Vector3 newMovePosition;

				newMovePosition = new Vector3();

				newMovePosition = lastPosition + moveReferenceObject.transform.right * lineData.horizontalSpacing * x;

				movePositions.Add(newMovePosition);
			}

			moveReferenceObject.transform.position -= moveReferenceObject.transform.forward * lineData.verticalSpacing;
		}

		Destroy(moveReferenceObject);

		return movePositions;
	}

	Vector3 lineCalc(int unitIndex, int groupSize)
	{
		Vector3 movePosition;

		movePosition = new Vector3();

		return movePosition;
	}

	GameObject createMoveReferenceObject(Vector3 groupLocation, Vector3 moveLocation)
	{
		GameObject moveObject;

		moveObject = new GameObject();
		moveObject.transform.position = moveLocation;
		moveObject.transform.LookAt(groupLocation);
		moveObject.transform.Rotate(0, 180, 0);

		return moveObject;
	}

	[System.Serializable]
	public class LineData
	{
		public int unitsPerLine;
		public float horizontalSpacing;
		public float verticalSpacing;
	}
}