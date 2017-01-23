using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class characterControls : MonoBehaviour {

	// Projectile

	public GameObject bulletOrigin;

	public GameObject prefabProjectile;

	public GameObject origin;

	// listener for sound effects
	public AudioSource effects;
	public static AudioSource music;
	//sound effects
	public AudioClip enemyHit;
	public AudioClip enemyDie;
	public AudioClip jump;
	public AudioClip char_attack;
	// soundtracks
	public AudioClip backgroundMusic;
	public AudioClip bossFight;
	public AudioClip victoryMusic;
	// life hearts
	public Image heart001;
	public Image heart002;
	public Image heart003;
	public Image heart004;
	public Image heart005;

	// coin text cofloat

	public Text coinUI;
	public Text lifeUI;
	//Stats
	public static int extraLife = 3;
	public static int health = 5;
	static public float coins = 0;
	static public int score = 10;
	//score
	public Text MYscore;
	//Floats

	public float maxSpeed = 3;
	public float highSpeed = 50;
	public float normalSpeed = 30;
	public float speed = 50;
	public float jumpPower = 150f;

	//Booleans
	public bool grounded;
	public bool canDoubleJump;

	//References
	private Rigidbody2D rb2d;
	private Animator anim;

	// Stats
	public float curHealth;
	public float maxHealth;

	// flag for a new level to restart vitals
	public static bool newLevel;

	// Use this for initialization
	void Start () {

		// Insure life bars are set
		heart001.enabled = true;
		heart002.enabled = true;
		heart003.enabled = true;
		heart004.enabled = true;
		heart005.enabled = true;

		//Reference the rigid body and animator
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();

		//set source
		music = this.GetComponents<AudioSource>()[1];


	}

	// Update is called once per frame
	void Update () {
		if (newLevel) {
			health = 5;
			newLevel = false;

		}
		MYscore.text = score.ToString();
		//Debug.Log (health);
		anim.SetBool ("isGrounded", grounded);
		anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
		//check lives
		if (extraLife < 0) {
			SceneManager.LoadScene ("gameOver", LoadSceneMode.Additive);
		}
		// check the health f(x)
		lowerHealth ();
		//Check score
		if (score <= 0) {
			if (extraLife >= 0) {
				musicTriggerLevel001.hasDied = true;
				transform.position = origin.transform.position;
				extraLife--;
				score = 10;
				MYscore.text = "10";
				health = 5;
			} else {
				health = 5;
				extraLife = 3;
				coins = 0;
				score = 10;
				SceneManager.LoadScene ("start", LoadSceneMode.Additive);
			}
		}
		// check death ()
		if (health <= 0) {
			if (extraLife >= 0) {
				musicTriggerLevel001.hasDied = true;
				transform.position = origin.transform.position;
				extraLife--;
				health = 5;
			} else {
				health = 5;
				extraLife = 3;
				coins = 0;
				score = 10;
				SceneManager.LoadScene ("start", LoadSceneMode.Additive);
			}
		}
		//check coins for extralife
		if (coins >= 25) {
			extraLife++;
			coins = 0;
		}
		// Update coins
		coinUI.text = coins.ToString();
		lifeUI.text = extraLife.ToString ();

		// Controls
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3 (-3.47459f, 3.442716f, 3.442716f);
			if (Input.GetKey (KeyCode.LeftShift)) {

				speed = highSpeed;

			} else
				speed = normalSpeed;
			
			// Debug.Log ("Left");
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3 (3.47459f, 3.442716f, 3.442716f);
			if (Input.GetKey (KeyCode.LeftShift)) {

				speed = highSpeed;

			} else
				speed = normalSpeed;


			// Debug.Log("Right");
		}
		if(Input.GetButtonDown("Jump")){
			if (grounded) {
				canDoubleJump = true;
				rb2d.AddForce ((Vector2.up * jumpPower));
				playSoundEffect ("jump");
			}	
			else if(canDoubleJump == true){
				canDoubleJump = false;
				rb2d.AddForce ((Vector2.up * jumpPower));
				playSoundEffect ("jump");
			}
		}

		// Attack

		if (Input.GetKeyDown ("b")) {
			attack ();
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Player_attack") == true) {
			playSoundEffect ("char_attack");
			anim.SetBool ("attacking", false);

		}

	}
	// sOUND fx
	public void playSoundEffect(string clip){
		switch (clip) {
		case "char_attack":
			effects.GetComponent<AudioSource> ().clip = char_attack;
			effects.GetComponent<AudioSource> ().Play ();
			break;
		case "hurt":
			effects.GetComponent<AudioSource> ().clip = enemyHit;
			effects.GetComponent<AudioSource> ().Play ();
			break;
		case "jump":
			effects.GetComponent<AudioSource> ().clip = jump;
			effects.GetComponent<AudioSource> ().Play ();
			break;
		}


	}

	void lowerHealth(){

		switch (health) {
		case 0:
			
			heart001.enabled = false;
			heart002.enabled = false;
			heart003.enabled = false;
			heart004.enabled = false;
			heart005.enabled = false;
			break;
		case 1:
			heart001.enabled = true;
			heart002.enabled = false;
			heart003.enabled = false;
			heart004.enabled = false;
			heart005.enabled = false;
			break;
		case 2:
			heart001.enabled = true;
			heart002.enabled = true;
			heart003.enabled = false;
			heart004.enabled = false;
			heart005.enabled = false;
			break;
		case 3:
			heart001.enabled = true;
			heart002.enabled = true;
			heart003.enabled = true;
			heart004.enabled = false;
			heart005.enabled = false;
			break;
		case 4:
			heart001.enabled = true;
			heart002.enabled = true;
			heart003.enabled = true;
			heart004.enabled = true;
			heart005.enabled = false;
			break;
		case 5:
			heart001.enabled = true;
			heart002.enabled = true;
			heart003.enabled = true;
			heart004.enabled = true;
			heart005.enabled = true;
			break;
		}

	}


	void attack(){

		GameObject projectile = Instantiate (prefabProjectile, bulletOrigin.transform.position, bulletOrigin.transform.rotation) as GameObject;

		// shoot right
		if(this.transform.localScale.x > 0)
			projectile.GetComponent<Rigidbody2D> ().AddForce (new Vector2(2, 1)* 2000);

		// shoot left
		if(this.transform.localScale.x < 0)
			projectile.GetComponent<Rigidbody2D> ().AddForce (new Vector2(-2, 1)* 2000);
		anim.Play ("Player_attack");

	}
	void FixedUpdate(){

		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.65f;

		float h = Input.GetAxis ("Horizontal");

		//Fake friction / Ease the x speed of our player
		if (grounded) {

			rb2d.velocity = easeVelocity;
		}

		//moving the player
		rb2d.AddForce ((Vector2.right * speed) * h);

		//Limiting the speed of the player
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}


	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag.Equals ("Enemy") == true) {
			playSoundEffect ("hurt");
			health -= 1;
			rb2d.AddForce (Vector2.up * 300);
		}


	}

}
