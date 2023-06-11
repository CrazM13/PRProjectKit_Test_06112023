using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

	[SerializeField] private AudioClip footsteps;
	[SerializeField] private BaseCharacterController character;

	[Header("Settings")]
	[SerializeField] private float volume;

	private AudioSource footstepAudio;

	// Start is called before the first frame update
	void Start() {
		footstepAudio = ServiceLocator.AudioManager.Play(footsteps);

		footstepAudio.loop = true;
	}

	// Update is called once per frame
	void Update() {
		if (character.CurrentSpeed > 0) {
			footstepAudio.UnPause();
		} else {
			footstepAudio.Pause();
		}

		footstepAudio.transform.position = transform.position;
		footstepAudio.volume = volume;
	}
}
