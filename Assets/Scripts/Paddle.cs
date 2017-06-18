using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public Rigidbody ball;
	public Rigidbody leftPaddle;
	public Rigidbody rightPaddle;

	private float speed = 10;
	private float ballXAxis;

	void Update () {

		ballXAxis = ball.transform.position.x;

		if (Input.GetKey (KeyCode.UpArrow)) {
			MoveUp ();
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			MoveDown ();
		}

		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow)) {
			StopMovement ();
		}

	}

	void MoveUp () {
		
		if (ballXAxis > 0) {
			leftPaddle.velocity = Vector3.zero;
			rightPaddle.velocity = new Vector3 (0, speed, 0);
		}
		if (ballXAxis < 0) {
			rightPaddle.velocity = Vector3.zero;
			leftPaddle.velocity = new Vector3 (0, speed, 0);
		}

	}

	void MoveDown () {
		
		if (ballXAxis > 0) {
			leftPaddle.velocity = Vector3.zero;
			rightPaddle.velocity = new Vector3 (0, -speed, 0);
		}
		if (ballXAxis < 0) {
			rightPaddle.velocity = Vector3.zero;
			leftPaddle.velocity = new Vector3 (0, -speed, 0);
		}

	}

	void StopMovement () {
		
		rightPaddle.velocity = Vector3.zero;
		leftPaddle.velocity = Vector3.zero;

	}

}