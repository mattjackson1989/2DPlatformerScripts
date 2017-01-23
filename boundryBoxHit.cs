using UnityEngine;
using System.Collections;

public class boundryBoxHit : MonoBehaviour {
	public GameObject origin;
	public GameObject player;
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals ("Player")) {
			characterControls.health = 5;
			characterControls.score = 10;
			characterControls.extraLife--;
			musicTriggerLevel001.hasDied = true;
			player.transform.position = origin.transform.position;
			//Debug.Break ();
		}

	}
}
