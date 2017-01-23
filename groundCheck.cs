using UnityEngine;
using System.Collections;

public class groundCheck : MonoBehaviour {

	public characterControls charControls;
	private characterControls Player;

	// Use this for initialization
	void Start () {
		Player = gameObject.GetComponentInParent<characterControls> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col){
		Player.grounded = true;
		if (col.gameObject.tag.Equals ("Enemy") == true) {
			col.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 500);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		Player.grounded = false;

	}

	void OnTriggerStay2D(Collider2D col){
		Player.grounded = true;
	}
}
