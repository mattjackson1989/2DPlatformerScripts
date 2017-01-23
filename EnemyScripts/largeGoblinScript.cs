using UnityEngine;
using System.Collections;

public class largeGoblinScript : MonoBehaviour {

	// enemy health

	public float enemyHealth = 3;
	//Floats
	public float maxSpeed = 3;
	public float speed = 30f;
	public float jumpPower = 150f;
	public float min;
	public float max;
	//References
	private Rigidbody2D rb2d;
	private Animator anim;

	// bools
	public bool moveLeft;
	public bool moveRight;
	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		moveRight = true;
		moveLeft = false;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x >= max) {
			transform.localScale = new Vector3 (-4.51f, transform.localScale.y, transform.localScale.z);
			moveLeft = true;
			moveRight = false;
		}
		if (transform.position.x <= min) {
			transform.localScale = new Vector3 (4.51f, transform.localScale.y, transform.localScale.z);
			moveLeft = false;
			moveRight = true;
		}
		if (enemyHealth <= 0) {
			Destroy (gameObject);
		}
	}

	void FixedUpdate(){

		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.65f;

		rb2d.velocity = easeVelocity;

		//moving the player
		if(moveRight)
			rb2d.AddForce ((Vector2.right * speed) * 2);
		if(moveLeft)
			rb2d.AddForce ((Vector2.left * speed) * 2);
		//Limiting the speed of the player
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
	}

	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.tag.Equals("fireball")){
			enemyHealth --;


		}

	}
}
