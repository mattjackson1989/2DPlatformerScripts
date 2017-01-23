using UnityEngine;
using System.Collections;

public class turtleTrigger : MonoBehaviour {


	public bool triggered;
	// Use this for initialization
	void Start () {
		triggered = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag.Equals ("Player") == true) {

			triggered = true;

		}
	}
}
