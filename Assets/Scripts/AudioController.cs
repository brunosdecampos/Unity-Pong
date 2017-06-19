using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	public AudioClip clip;

	private AudioSource source;

	void Awake () {

		source = GetComponent<AudioSource> ();

	}

	void OnCollisionEnter (Collision collision) {

		if (collision.gameObject.tag == "Ball") {
			source.PlayOneShot (clip);
		}

	}

}