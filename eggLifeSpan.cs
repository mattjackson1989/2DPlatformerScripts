using UnityEngine;
using System.Collections;

public class eggLifeSpan : MonoBehaviour {

	private Vector2 startLocation;
	private Vector2 curLocation;


	// Use this for initialization
	void Start () {
		startLocation = transform.position;
	}

	// Update is called once per frame
	void Update () {
		curLocation = transform.position;

		if (((startLocation.y - curLocation.y) >= 10)) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag.Equals("Player")){
			characterControls.health -= 1;
			col.GetComponent<Rigidbody2D>().AddForce (Vector2.up * 500);
			Destroy (gameObject);
		}



	}
}