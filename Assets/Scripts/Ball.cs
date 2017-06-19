using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Vector3 direction;
	private float speed = 4f;
	private float ballYAxisPosition, ballYAxisDirection, ballXAxisDirection;

	void Start () {

		PrepareBall ();
		direction.Normalize ();

	}

	void Update () {

		this.transform.position += direction * speed * Time.deltaTime;

	}

	float GenerateNumber (float from, float to) {
		
		return Random.Range (from, to);

	}

	void PrepareBall (string side = "Left") {

		ballYAxisPosition = GenerateNumber (-4f, 4f);

		this.transform.position = new Vector3 (0, ballYAxisPosition, 0);

		if (ballYAxisPosition >= 0) {
			ballYAxisDirection = -GenerateNumber (0.5f, 1f);
		} else {
			ballYAxisDirection = GenerateNumber (0.5f, 1f);
		}

		if (side == "Right") {
			ballXAxisDirection = 1;
		} else {
			ballXAxisDirection = -1;
		}

		direction = new Vector3 (ballXAxisDirection, ballYAxisDirection, 0);

	}

	void OnCollisionEnter (Collision collision) {
		
		Vector3 normalVector = collision.contacts [0].normal;

		direction = Vector3.Reflect (direction, normalVector);
		direction.Normalize ();

		if (collision.gameObject.tag == "LeftBoundary") {
			GameController.instance.IncrementScore ("Right");
			PrepareBall ();
		}

		if (collision.gameObject.tag == "RightBoundary") {
			GameController.instance.IncrementScore ("Left");
			PrepareBall ("Right");
		}

	}

}