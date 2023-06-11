using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pellet : MonoBehaviour {

	private static PelletManager pelletManager;

	[SerializeField] private AudioClip collectionSound;

	[SerializeField] private UnityEvent OnPelletEaten = new UnityEvent();

	private void Start() {
		if (pelletManager == null) pelletManager = new PelletManager();

		pelletManager.RegisterPellet(this);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			OnPelletEaten.Invoke();

			ServiceLocator.AudioManager.Play(collectionSound, transform.position);

			pelletManager.UnegisterPellet(this);
			Destroy(gameObject);
		}
	}

}
