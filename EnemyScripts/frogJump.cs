using UnityEngine;
using System.Collections;



public class frogJump : MonoBehaviour {

	// enemy health

	public float enemyHealth = 2;
	public float jumpTime = 3.30f;
	public float jumpPower = 2000;
	private float timer;
	public Rigidbody2D frogMan;

	// Use this for initialization
	void Start () {
		timer = jumpTime;
		frogMan = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {

			frogMan.AddForce (Vector2.up * jumpPower);
			timer = jumpTime;
			//Debug.Log ("Worked");
		}
		if (enemyHealth <= 0) {
			characterControls.score--;
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.tag.Equals("fireball")){
			enemyHealth --;


		}

	}
}
