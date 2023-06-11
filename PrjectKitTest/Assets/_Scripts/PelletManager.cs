using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletManager {

	private List<Pellet> pellets;

	public PelletManager() {
		pellets = new List<Pellet>();
	}

	public void RegisterPellet(Pellet pellet) {
		pellets.Add(pellet);
	}

	public void UnegisterPellet(Pellet pellet) {
		pellets.Remove(pellet);

		if (pellets.Count <= 0) {
			Debug.Log("Win!");
		}
	}
}
