using UnityEngine;
using System.Collections;

public class coinDestroy : MonoBehaviour {
	public AudioSource listener;

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag.Equals ("Player") == true) {
			characterControls.coins++;
			listener.GetComponent<AudioSource> ().Play ();
			Destroy (gameObject, 0.2f);

		}

	}
}
