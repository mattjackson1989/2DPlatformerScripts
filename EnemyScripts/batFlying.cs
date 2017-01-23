using UnityEngine;
using System.Collections;

public class batFlying : MonoBehaviour {
	public int enemyHealth = 1;
	public float minY = 4.5f;
	public float minX;
	public float speed;
	public float maxDistance = 80;
	private bool isMoving;
	public Rigidbody2D velocity;
	// Use this for initialization
	float posx;
	float posy;
	void Start () {
		velocity = this.GetComponent<Rigidbody2D> ();
		isMoving = false;
		this.GetComponent<Rigidbody2D> ().isKinematic = true;
		posx = transform.position.x;
		posy = transform.position.y;
	}

	void Update(){
		if (enemyHealth <= 0) {
			enemyHealth = 1;
			transform.position = new Vector3 (posx, posy, -5);
			this.GetComponent<Animator> ().SetBool ("trigger", false);

			this.GetComponent<Rigidbody2D>().isKinematic = true;
			this.GetComponent<Rigidbody2D> ().constraints -= RigidbodyConstraints2D.FreezePositionY;
			this.GetComponent<Rigidbody2D> ().isKinematic = true;
			isMoving = false;

		}
		transform.rotation = Quaternion.Euler (0, 0, 0);
		if (isMoving == true) {

			this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-speed, 0) * 100);
		}
		// reset position once x threshhold has been reached
		if (transform.position.x <= minX) {
			this.GetComponent<Animator> ().SetBool ("trigger", false);

			this.GetComponent<Rigidbody2D>().isKinematic = true;
			this.GetComponent<Rigidbody2D> ().constraints -= RigidbodyConstraints2D.FreezePositionY;
			transform.position = new Vector3 (posx, posy, -5);
			isMoving = false;
			}


	}
	// Update is called once per frame
	void FixedUpdate () {
		
		if (this.transform.position.y <= minY) {
			
			 // Debug.Log ("It is passed minY");
			this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionY;
			isMoving = true;
		}

		if (velocity.velocity.x >= 2) {

			//Debug.Log ((float)velocity.velocity.x);

		}
	}

	private void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag.Equals("Player")){
			this.GetComponent<Animator> ().SetBool ("trigger", true);
			this.GetComponent<Rigidbody2D> ().isKinematic = false;

		}

	}
	private void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag.Equals("fireball") == true ){
			enemyHealth--;
		}

	}

}
