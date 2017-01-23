using UnityEngine;
using System.Collections;

public class endLevel : MonoBehaviour {
	public GameObject loadScreen;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals ("Player")) {
			characterControls.newLevel = true;
			loadScreen.SetActive(true);
			Application.LoadLevel ("level002");

		}

	}
}
