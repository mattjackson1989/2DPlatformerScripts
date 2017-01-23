using UnityEngine;
using System.Collections;

public class squirrelTrigger : MonoBehaviour {
	
	public AudioSource listener;
	public AudioClip clip;
	public GameObject squirell;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (squirell.transform.position.y < -20) {
			squirell.GetComponent<Rigidbody2D> ().isKinematic = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag.Equals("Player")){
			listener.GetComponent<AudioSource> ().clip = clip;
			listener.GetComponent<AudioSource> ().Play ();
			squirell.GetComponent<Animator> ().SetBool ("trigger", true);
			squirell.GetComponent<Rigidbody2D> ().isKinematic = false;

			//squirell.GetComponent<Rigidbody2D> ().AddForce (Vector2.down* 2000);
		}

	}

	void FixedUpdate () {
		
			//squirell.GetComponent<Rigidbody2D> ().AddForce (Vector2.down * 1000);
	}
}
