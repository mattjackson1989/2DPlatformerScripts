using UnityEngine;
using System.Collections;

public class fireLifeSpan : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < 5) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Equals("Player")){
			characterControls.health--;

			Destroy (gameObject);
		}

	}
}
