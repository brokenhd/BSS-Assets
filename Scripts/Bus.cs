using UnityEngine;
using System.Collections;

public class Bus : MonoBehaviour {
	public static bool bus;
	public bool lift;

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "Main Camera")
		bus = true;
	}


	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.name == "Main Camera")
		bus = false;
	}
}
