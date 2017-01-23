using UnityEngine;
using System.Collections;

public class snakeBoss : MonoBehaviour {
	public GameObject bulletOrigin;
	public GameObject fireStream;
	public GameObject fireOrigin;
	//public AudioSource musicPlayer;
	public AudioClip victory;
	public AudioSource snakeSoundEffects;
	int cycles;
	bool hit;
	public static int health;
	public static bool engaged;
	public int cycleSpeed;
	int fireloop;
	// Use this for initialization
	void Start () {
		cycles = 0;
		health = 5;
		fireloop = 0;
		hit = false;
		engaged = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			characterControls.music.clip = victory;
			characterControls.music.Play ();
			snakeSoundEffects.GetComponent<AudioSource> ().Play ();
			Destroy (gameObject, 2);
		}
		//when to attack
		if (engaged == true) {
			if (cycles > cycleSpeed) {
				this.GetComponent<Animator> ().SetBool ("attack", true);
				GameObject projectile = Instantiate (fireStream, bulletOrigin.transform.position, bulletOrigin.transform.rotation) as GameObject;
				// shoot left
				if (this.transform.localScale.x > 0)
					projectile.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-2, 1) * 75);
				cycles = 0;
			} else {
				this.GetComponent<Animator> ().SetBool ("attack", false);
				++cycles;

			}
			if (fireloop >= 300) {
				fireOrigin.SetActive (true);
			}
			fireloop++;
		}
		if (cycles >= 100 && hit) {
			this.GetComponent<Animator> ().SetBool ("hit", false);
			hit = false;
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag.Equals("rebound") == true){
			health--;
			hit = true;
			cycles = 0;
			this.GetComponent<Animator> ().SetBool ("hit", true);

		}

	}
	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag.Equals("rebound") == true){
			health--;
			//this.GetComponent<Animator> ().SetBool ("hit", false);

		}

	}
}
