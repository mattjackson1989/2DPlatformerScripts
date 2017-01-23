using UnityEngine;
using System.Collections;

public class bulletLifeSpan : MonoBehaviour {

	private Vector2 startLocation;
	private Vector2 curLocation;


	// Use this for initialization
	void Start () {
		startLocation = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		curLocation = transform.position;

		if (((curLocation.x - startLocation.x) >= 10) || curLocation.y <= -6) {
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag.Equals ("Enemy") == true) {



		}
		Destroy (gameObject);

	}
}
