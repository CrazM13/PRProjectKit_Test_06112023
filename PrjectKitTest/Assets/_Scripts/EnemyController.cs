using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] private BaseCharacterController characterController;
	[SerializeField] private Transform player;
	[SerializeField] private float detectionRadius;

	private float afraidTime = 0;

	// Start is called before the first frame update
	void Start() {
		if (!player) player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update() {
		if (player) {
			if (afraidTime > 0) {
				MoveAwayFromPlayer();
			} else {
				MoveTowardsPlayer();
			}

			if (CheckForPlayer()) {
				if (afraidTime > 0) {
					Destroy(gameObject);
				} else {
					ServiceLocator.SceneManager.LoadScene(ServiceLocator.SceneManager.GetCurrentSceneName());
				}
			}
		}

		if (afraidTime > 0) afraidTime -= GameTime.GetDeltaTime("CharacterTime");
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

	private void MoveAwayFromPlayer() {
		NavMeshPath path = new NavMeshPath();

		Vector3 badDirection = player.position - transform.position;

		NavMesh.CalculatePath(transform.position, transform.position + (-10 * badDirection.normalized), -1, path);

		if (path.corners.Length > 1) {
			Vector3 targetLocation = path.corners[1];

			characterController.Move(targetLocation - transform.position);
		} else {
			characterController.Move(badDirection.normalized);
		}
	}

	private bool CheckForPlayer() {
		RaycastHit[] hits = Physics.SphereCastAll(transform.position, detectionRadius, Vector3.up);

		foreach (RaycastHit hit in hits) {
			if (hit.collider.gameObject.tag == "Player") return true;
		}

		return false;
	}

	public void SetAfraid(float time) {
		this.afraidTime = time;
	}
}
