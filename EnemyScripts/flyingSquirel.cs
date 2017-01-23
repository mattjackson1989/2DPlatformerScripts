using UnityEngine;
using System.Collections;

public class flyingSquirel : MonoBehaviour {


	public GameObject sqrlTrigger;
	float originx, originy, originz;
	// Use this for initialization
	void Start () {
		originx = transform.position.x;
		originy = transform.position.y;
		originz = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -20) {
			transform.position = new Vector3 (originx, originy, originz);
			this.GetComponent<Rigidbody2D> ().isKinematic = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag.Equals("Player")){
			characterControls.health--;
			col.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-1, 1)* 250);
		}

	}
}
