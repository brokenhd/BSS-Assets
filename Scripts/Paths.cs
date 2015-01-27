using UnityEngine;
using System.Collections;

public class Paths : MonoBehaviour {
	public float moveSpeed;
	public GameObject[] pathStart;
	public GameObject[] pathEnd;
	public GameObject[] pedestrians;
	GameObject Player;
	
	
	void Start() {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Debug.Log("Hello");
	}
	
	void Update() {
		
		for (int i = 0; i < pedestrians.Length; i++) {
			
			pedestrians[i].gameObject.transform.position = Vector2.Lerp (pedestrians[i].gameObject.transform.localPosition, pathEnd[i].gameObject.transform.position, Time.deltaTime * moveSpeed);
			
		}
		
		
		
	}
}

