using UnityEngine;
using System.Collections;

public class snail : MonoBehaviour {

	// enemy health
	public float enemyHealth = 2;
	//Floats
	public float maxSpeed = 3;
	public float speed = 30f;
	public float jumpPower = 150f;
	public float localScale;
	public float max, min;
	public float originx, originy, originz;
	//References
	private Rigidbody2D rb2d;
	private Animator anim;
	// sound effects
	public AudioSource listener;
	public AudioClip hit;
	public AudioClip death;
	// bools
	public bool moveLeft;
	public bool moveRight;
	public bool respawn;

	// Use this for initialization
	void Start () {
		localScale = transform.position.x;
		//Debug.Log (localScale);
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		moveRight = true;
		moveLeft = false;

		originx = transform.position.x;
		originy = transform.position.y;
		originz = transform.position.z;
	}

	// Update is called once per frame
	void Update () {
		
		if (transform.position.x >= max) {
			transform.localScale = new Vector3 (3.8f, transform.localScale.y, transform.localScale.z);
			moveLeft = true;
			moveRight = false;
		}
		if (transform.position.x <= min) {
			transform.localScale = new Vector3 (-3.8f, transform.localScale.y, transform.localScale.z);
			moveLeft = false;
			moveRight = true;
		}

		if (enemyHealth <= 0) {
			
			listener.GetComponent<AudioSource> ().clip = death;
			listener.GetComponent<AudioSource> ().Play ();
			characterControls.score--;
			if (respawn) {
				enemyHealth = 2; 
				transform.position = new Vector3 (originx, originy, originz);
			} else {
				Destroy (gameObject);
			}

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
		
		if(col.gameObject.tag.Equals("fireball") == true ){
			if (enemyHealth >= 1) {
				listener.GetComponent<AudioSource> ().clip = hit;
				listener.GetComponent<AudioSource> ().Play ();
			} 
			enemyHealth --;
		}

	}
}
