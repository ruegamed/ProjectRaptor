using UnityEngine;
using System.Collections;

public class UnitScript : MonoBehaviour
{
	public Vector3 facingDirection;

	private NavMeshAgent navMeshAgent;

	void Start()
	{
		navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
		facingDirection = navMeshAgent.nextPosition;
	}

	void Update ()
	{
		setFacingDirection();
	}

	private void setFacingDirection()
	{
		NavMeshPath nmp;

		nmp = navMeshAgent.path;

		facingDirection = Quaternion.LookRotation(nmp.corners[nmp.corners.Length-1] - gameObject.transform.position).eulerAngles;
	}
}
