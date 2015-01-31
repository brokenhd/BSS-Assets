using UnityEngine;
using System.Collections;

public class Paths : MonoBehaviour {
	public float moveSpeed;
	public GameObject[] pathStart;
	public GameObject[] pathEnd;
	public GameObject[] pedestrians;

	
	
	void Start() {
		for (int i = 0; i < pedestrians.Length; i++) {
			pedestrians[i].gameObject.transform.position = pathStart[i].gameObject.transform.position;
		}
	}
	
	void Update() {


		
		for (int i = 0; i < pedestrians.Length; i++) {
			
			pedestrians[i].gameObject.transform.position = Vector2.MoveTowards (pedestrians[i].gameObject.transform.localPosition, pathEnd[i].gameObject.transform.position, Time.deltaTime * moveSpeed);

			if (pedestrians[i].gameObject.transform.position.x == pathEnd[i].gameObject.transform.position.x  ){
				pedestrians[i].gameObject.GetComponent<Animator>().SetBool("walking", false);
			} else {
				pedestrians[i].gameObject.GetComponent<Animator>().SetBool("walking", true);
			}

			
		}
	}

	public void resetPath() {
		ShuffleArray(pathStart);
		ShuffleArray(pathEnd);
		for (int i = 0; i < pedestrians.Length; i++) {
			pedestrians[i].gameObject.transform.position = pathStart[i].gameObject.transform.position;
			pedestrians[i].gameObject.GetComponent<Pedestrian>().beenClicked = false;
			pedestrians[i].gameObject.GetComponent<Pedestrian>().chatContainer.gameObject.GetComponent<CanvasGroup>().alpha = 0;
		}
	}


	public static void ShuffleArray<T>(T[] arr) {

		for (int i = arr.Length - 1; i > 0; i--) {
			int r = Random.Range(0, i);
			T tmp = arr[i];
			arr[i] = arr[r];
			arr[r] = tmp;
		}
	}

}

