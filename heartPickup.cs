using UnityEngine;
using System.Collections;

public class heartPickup : MonoBehaviour {
	public AudioSource pickup;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag.Equals("Player")){

			if (characterControls.health < 5) {
				characterControls.health++;
				pickup.GetComponent<AudioSource> ().Play ();
				Destroy (gameObject, 0.5f);
			}
		}

	}
}
