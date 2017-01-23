using UnityEngine;
using System.Collections;

public class flyingTurtle : MonoBehaviour {

	public GameObject origin;
	public GameObject egg;
	public GameObject trigger;
	float health = 2;

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);

	}
	
	// Update is called once per frame
	void Update () {


		if (health <= 0)
			Destroy (gameObject);

		if (trigger.GetComponent<turtleTrigger> ().triggered == true) {
			
			// trigger.GetComponent<turtleTrigger> ().triggered = false;
		}


	}

	void FixedUpdate(){

		if (trigger.GetComponent<turtleTrigger>().triggered == true)
			this.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.left);
		// Debug.Log (gameObject.GetComponent<Rigidbody2D>().velocity.x);
		if (this.GetComponent<Rigidbody2D>().velocity.x < -3) {
			
			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (-3, this.GetComponent<Rigidbody2D>().velocity.y);
		}

	}

	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.tag.Equals("fireball")){

			health--;

		}

	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag.Equals ("Player") == true) {

			attack ();

		}

	}
	void OnTriggerLeave2D(Collider2D col){

		if (col.gameObject.tag.Equals ("Player") == true) {

			attack ();

		}

	}
		

	void attack(){

		this.GetComponent<Animator> ().Play ("turtleBird_attack");

		GameObject projectileT = Instantiate (egg, transform.position + new Vector3(-1.5f, -1, -1), transform.rotation) as GameObject;

		Debug.Log (projectileT.transform.position);
			//projectile.GetComponent<Rigidbody2D> ().AddForce (new Vector2(-1, 0)* 500);

		this.GetComponent<Animator> ().SetBool ("attacking", false);

	}
		
}

