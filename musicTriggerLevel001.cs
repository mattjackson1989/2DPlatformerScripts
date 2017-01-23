using UnityEngine;
using System.Collections;

public class musicTriggerLevel001 : MonoBehaviour {
	public AudioSource listener;
	public AudioClip soundclip;
	public static bool hasDied;
	// Use this for initialization
	void Start () {
		hasDied = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals ("Player") && hasDied) {
			characterControls.music.clip = soundclip;
			characterControls.music.Play ();
			hasDied = false;
		}

	}
}
