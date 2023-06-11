using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour {

	[SerializeField] private Zone parent;
	[SerializeField] private string requiredTag;

	private void OnTriggerEnter(Collider other) {
		if (string.IsNullOrEmpty(requiredTag) || other.gameObject.tag == requiredTag) parent.EnterZone();
	}

	private void OnTriggerExit(Collider other) {
		if (string.IsNullOrEmpty(requiredTag) || other.gameObject.tag == requiredTag) parent.ExitZone();
	}

}
