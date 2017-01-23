using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class mossTrigger : MonoBehaviour {
	//public GameObject character;
	public AudioSource battlemusic;
	public AudioClip battle;
	//public AudioSource playerMusic;
	// Use this for initialization
	void Start () {
//		player = GetComponents<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Equals("Player") == true){
			snakeBoss.engaged = true;
			characterControls.music.clip = battle;
			characterControls.music.Play ();

			Destroy (gameObject);
		}


	}
}
