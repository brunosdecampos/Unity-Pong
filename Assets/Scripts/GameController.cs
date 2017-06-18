using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public GameObject arena;
	public GameObject result;

	public Text leftTextScore;
	public Text rightTextScore;
	public Text result1Text;
	public Text result2Text;
	public Text rematch1Text;
	public Text rematch2Text;

	private int maxScore = 12;
	private int leftScore = 0;
	private int rightScore = 0;

	private string result1;
	private string result2;
	private string rematch1;
	private string rematch2;

	private bool gameOver = false;

	void Start () {

		instance = this;
		result.SetActive (false);

	}

	void Update () {
		
		if (gameOver == true) {
			if (Input.anyKey && !Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.DownArrow)) {
				RestartGame ();
			}
		}

	}

	void RestartGame () {

		SceneManager.LoadScene ("Main");

	}

	public void IncrementScore (string side) {
		
		if (side == "Left") {
			leftScore++;

			if (leftScore < maxScore) {
				leftTextScore.text = leftScore.ToString();
			} else {
				Result (1);
			}
		}

		if (side == "Right") {
			rightScore++;

			if (rightScore < maxScore) {
				rightTextScore.text = rightScore.ToString ();
			} else {
				Result (2);
			}
		}

	}

	public void Result (int winner) {
		
		if (winner == 1) {
			result1 = "You win";
			result2 = "You lose";
			rematch1 = "";
			rematch2 = "Rematch";
		}

		if (winner == 2) {
			result1 = "You lose";
			result2 = "You win";
			rematch1 = "Rematch";
			rematch2 = "";
		}

		result1Text.text = result1;
		result2Text.text = result2;
		rematch1Text.text = rematch1;
		rematch2Text.text = rematch2;

		result.SetActive (true);
		arena.SetActive (false);

		gameOver = true;

	}

}