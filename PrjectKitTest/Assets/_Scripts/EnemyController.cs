using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] private BaseCharacterController characterController;
	[SerializeField] private Transform player;



	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if (player) {
			MoveTowardsPlayer();
		}
	}

	private void MoveTowardsPlayer() {
		NavMeshPath path = new NavMeshPath();

		NavMesh.CalculatePath(transform.position, player.position, -1, path);

		if (path.corners.Length > 1) {
			Vector3 targetLocation = path.corners[1];

			characterController.Move(targetLocation - transform.position);
		} else {
			Vector3 targetDirection = player.position - transform.position;

			characterController.Move(targetDirection.normalized);
		}
	}
}
