using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pellet : MonoBehaviour {

	[SerializeField] private UnityEvent OnPelletEaten = new UnityEvent();

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			OnPelletEaten.Invoke();

			Destroy(gameObject);
		}
	}

}
