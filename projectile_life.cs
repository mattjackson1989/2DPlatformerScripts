using UnityEngine;
using System.Collections;

public class projectile_life : MonoBehaviour {
	int health;
	// Use this for initialization
	void Start () {
		health = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag.Equals("fireball")){
			this.gameObject.tag = "rebound";
			transform.localScale = new Vector3 (transform.localScale.x/2, transform.localScale.y/2, transform.localScale.z/2);
			health--;
		}
		if (col.gameObject.tag.Equals ("Enemy") && this.gameObject.tag == "rebound") {
			Destroy (gameObject);

		} 
		if(col.gameObject.tag.Equals ("ground")){
			Destroy(gameObject);

		}

	}
}
