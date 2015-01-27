using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pedestrian : MonoBehaviour {

	public Text chatBox;
	public Button correctAnswer;
	public Button wrongAnswer;
	public string dayOne;
	public string dayOneA1;
	public string dayOneA1Response;
	public string dayOneA2;
	public string dayOneA2Response;
	public string dayTwo;
	public string dayTwoA1;
	public string dayTwoA1Response;
	public string dayTwoA2;
	public string dayTwoA2Response;
	public string dayThree;
	public string dayThreeA1;
	public string dayThreeA1Response;
	public string dayThreeA2;
	public string dayThreeA2Response;
	public string dayFour;
	public string dayFourA1;
	public string dayFourA1Response;
	public string dayFourA2;
	public string dayFourA2Response;
	public string dayFive;
	public string dayFiveA1;
	public string dayFiveA1Response;
	public string dayFiveA2;
	public string dayFiveA2Response;
	public string daySix;
	public string daySixA1;
	public string daySixA1Response;
	public string daySixA2;
	public string daySixA2Response;

	float timer = 2f;
	bool beenClicked = false;
	bool triggered = false;
	GameObject chatContainer;

	void Awake() {

	}

	void Start() {
		chatContainer = GameObject.Find ("Container");

		correctAnswer.onClick.AddListener (() => { ClickedCorrectAnswer (); });
		wrongAnswer.onClick.AddListener (() => { ClickedWrongAnswer (); });

		chatContainer.GetComponent<CanvasGroup>().alpha = 0;
		beenClicked = false;
	}

	void OnMouseDown() {
		// If you already clicked this guy, dont do anything else
		if(beenClicked) return;

		// Set the chat field to current level string
		chatBox.text = dayOne;
		chatContainer.GetComponent<CanvasGroup>().alpha = 1;

		// Set the character to be clicked
		beenClicked = true;
	}

	void ClickedCorrectAnswer() {
		chatBox.text = "You are very nice.";
		correctAnswer.interactable = false;
		wrongAnswer.interactable = false;
		triggered = true;
	}

	void ClickedWrongAnswer() {
		chatBox.text = "You big jerk!";
		correctAnswer.interactable = false;
		wrongAnswer.interactable = false;
		triggered = true;		
	}

	void Update() {
		if(triggered) timer -= Time.deltaTime;
		if (timer <= 0f) {
			chatContainer.GetComponent<CanvasGroup>().alpha = 0;
		}
	}
}
