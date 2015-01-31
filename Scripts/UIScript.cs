using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

	public GameObject score;
	public GameObject uiTimer;
	public GameObject uiDay;
	string pointString = points.ToString();
	public static int points = 0;
	private Text scoreText;
	private Text uiTimerText;
	private Text uiDayText;
	GameObject paths;
	GameObject busObject;


	
	public float dayTimer = 60f; //Sets the day time to be adjustable in the editor
	private float newDayTimer;   // This variable keeps the time to what was initially set in the script or editor.
	public static int currentDay = 1; // day starts at 1;
	public bool busOnScreen = false;


	// Use this for initialization
	void Start () {
		paths  = GameObject.Find("Paths");
		busObject = GameObject.Find("bus");
		newDayTimer = dayTimer;
		scoreText = score.GetComponent<Text> ();
		scoreText.text = "score: " + pointString;
		uiTimerText = uiTimer.GetComponent<Text> ();
		uiTimerText.text = "Timer: " + ((int)dayTimer).ToString();
		uiDayText = uiDay.GetComponent<Text> ();
		uiDayText.text = "Day: " + currentDay.ToString();
	}

	// Update is called once per frame
	void Update () {
		busOnScreen = Bus.bus;
		pointString = points.ToString ();
		scoreText.text = "score: " + pointString;
		uiTimerText.text = "Timer: " + ((int)dayTimer).ToString();
		uiDayText.text = "Day: " + currentDay.ToString();



		if (dayTimer > 0) {
			dayTimer -= Time.deltaTime;
		}
		if (dayTimer <= 0) {
			busObject.GetComponent<Animator>().SetBool("bus", true);

			if (busOnScreen) {
				if(busObject.GetComponent<Bus>().lift) {
					paths.gameObject.GetComponent<Paths>().resetPath();
				}
			} else {
				if (dayTimer <= 0) {
					resetDay();
					busObject.GetComponent<Animator>().SetBool("bus", false);
				}
			}
		}
	
	}




	public static void addPoint(){
		points += 1;
	}
	public static void removePoint(){
		points -= 1;
	}

	void resetDay() {
		dayTimer = newDayTimer;
		currentDay++;
	}


}
