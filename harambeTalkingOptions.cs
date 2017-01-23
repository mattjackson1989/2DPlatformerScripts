using UnityEngine;
using System.Collections;

public class harambeTalkingOptions : MonoBehaviour {
	public GameObject Harambe;
	bool walk;
	float positionx;
	float positiony;
	float positionz;
	// Use this for initialization
	void Start () {
		walk = false;
		positionx = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals ("Player")) {
			
		}
	}
}
