using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : MonoBehaviour {

	[SerializeField] private float duration;

	public void OnEaten() {
		EnemyController[] enemies = GameObject.FindObjectsOfType<EnemyController>();

		foreach (EnemyController enemy in enemies) enemy.SetAfraid(duration);
	}

}
