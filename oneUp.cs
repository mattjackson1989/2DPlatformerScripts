using UnityEngine;
using System.Collections;

public class oneUp : MonoBehaviour {
	public AudioClip pickUpSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals ("Player")) {
			characterControls.extraLife++;
			this.gameObject.GetComponent<AudioSource> ().PlayOneShot (pickUpSound);
			yield return new WaitForSeconds (pickUpSound.length);
			Destroy (gameObject);
		}

	}
}
