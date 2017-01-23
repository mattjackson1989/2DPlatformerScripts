using UnityEngine;
using System.Collections;

public class outOfBoundslevel2 : MonoBehaviour {
	public GameObject loadScrean;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals ("Player")) {
			characterControls.health = 5;
			characterControls.extraLife--;
			characterControls.score = 10;
			loadScrean.SetActive(true);
			Application.LoadLevel("level003");

		}

	}
}
