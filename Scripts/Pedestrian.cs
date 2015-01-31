using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pedestrian : MonoBehaviour {

	public Text chatBox;
	public Button correctAnswer;
	public GameObject AnswerOneText;
	public Button wrongAnswer;
	public GameObject AnswerTwoText;
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


	int currentDay = 1;
	float timer = 2f;
	private float timerInitiall;
	public bool beenClicked = false;
	bool triggered = false;
	public GameObject chatContainer;

	void Start() {
		timerInitiall = timer;

		correctAnswer.onClick.AddListener (() => { ClickedCorrectAnswer (); });
		wrongAnswer.onClick.AddListener (() => { ClickedWrongAnswer (); });
		chatContainer.gameObject.GetComponent<CanvasGroup>().alpha = 0;

		beenClicked = false;

	}
	

	void OnMouseDown() {

		// If you already clicked this guy, dont do anything else
		if(beenClicked) return;

		// Set the chat field to current level string
		
		if(currentDay == 1) {
			chatBox.text = dayOne; // Figure out how to change day text on level switch
			AnswerOneText.GetComponent<Text>().text = dayOneA1;
			AnswerTwoText.GetComponent<Text>().text = dayOneA2;
			Debug.Log (gameObject.name);

		} else if(currentDay == 2) {
			chatBox.text = dayTwo; // Figure out how to change day text on level switch
			AnswerOneText.GetComponent<Text>().text = dayTwoA1;
			AnswerTwoText.GetComponent<Text>().text = dayTwoA2;	
			Debug.Log (gameObject.name);
		} else if(currentDay == 3) {
			chatBox.text = dayThree; // Figure out how to change day text on level switch
			AnswerOneText.GetComponent<Text>().text = dayThreeA1;
			AnswerTwoText.GetComponent<Text>().text = dayThreeA2;

		} else if(currentDay == 4) {
			chatBox.text = dayFour; // Figure out how to change day text on level switch
			AnswerOneText.GetComponent<Text>().text = dayFourA1;
			AnswerTwoText.GetComponent<Text>().text = dayFourA2;

		} else if(currentDay == 5) {
			chatBox.text = dayFive; // Figure out how to change day text on level switch
			AnswerOneText.GetComponent<Text>().text = dayFiveA1;
			AnswerTwoText.GetComponent<Text>().text = dayFiveA2;

		} else if(currentDay == 6) {
			chatBox.text = daySix; // Figure out how to change day text on level switch
			AnswerOneText.GetComponent<Text>().text = daySixA1;
			AnswerTwoText.GetComponent<Text>().text = daySixA2;

		} else {
			return;
		}

		chatContainer.gameObject.GetComponent<CanvasGroup>().alpha = 1;

		// Set the character to be clicked
		beenClicked = true;

	}

	void ClickedCorrectAnswer() {
		chatBox.text = dayOneA1Response;
		correctAnswer.interactable = false;
		wrongAnswer.interactable = false;
		triggered = true;
		UIScript.addPoint ();
	}

	void ClickedWrongAnswer() {
		chatBox.text = dayOneA2Response;
		correctAnswer.interactable = false;
		wrongAnswer.interactable = false;
		triggered = true;	
		UIScript.removePoint ();
	}

	void Update() {
		if(triggered) timer -= Time.deltaTime;
		if (timer <= 0f) {
			chatContainer.gameObject.GetComponent<CanvasGroup>().alpha = 0;
			timer = timerInitiall;
			correctAnswer.interactable = true;
			wrongAnswer.interactable = true;
			triggered = false;
		}
		currentDay = UIScript.currentDay; // references the day maintained in the UIScript

	}
}
