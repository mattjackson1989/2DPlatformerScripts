using UnityEngine;
using System.Collections;

public class trunkMan : MonoBehaviour {
	public GameObject leftOrigin;
	public GameObject rightOrigin;
	public GameObject prefabProjectile;
	public static bool AttackLeft;
	public static bool AttackRight;
	public int counter;
	public int health;
	// Use this for initialization
	void Start () {
		AttackLeft = false;
		AttackRight = false;
		health = 3;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy (gameObject);
		}
		if (AttackLeft == true) {
			if (counter >= 50) {
				GameObject projectile = Instantiate (prefabProjectile, leftOrigin.transform.position, leftOrigin.transform.rotation) as GameObject;
				projectile.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-2, 1) * Random.Range(200, 1000));
				this.GetComponent<Animator> ().Play ("attack");
				counter = 0;
				//this.GetComponent<Animator> ().SetBool ("isAttacking", false);
			}
		} else if (AttackRight == true) {
			if (counter >= 50) {
				GameObject projectile = Instantiate (prefabProjectile, rightOrigin.transform.position, rightOrigin.transform.rotation) as GameObject;
				projectile.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (2, 1) * Random.Range (200, 1000));
				//transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				this.GetComponent<Animator> ().Play ("attack");
				counter = 0;
			}
		}
		counter++;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag.Equals ("fireball")) {
			health--;
		}

	}
}
