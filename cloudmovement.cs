using UnityEngine;
using System.Collections;

public class cloudmovement : MonoBehaviour {
	private Rigidbody2D rb2d;
	public float speed = 30f;
	public float maxSpeed = 3;
	float originx, originy, originz;
	// Use this for initialization
	void Start () {
		
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		originx = transform.localPosition.x;
		originy = transform.localPosition.y;
		originz = transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () {
		
		rb2d.AddForce ((Vector2.left * speed) * 0.03f);
		if (this.transform.localPosition.x < -5) {
			this.transform.localPosition = new Vector3 (-1, originy, originz);
		}

		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
	}
}
