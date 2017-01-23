using UnityEngine;
using System.Collections;

public class trunkManAttackleft : MonoBehaviour {
	//public GameObject attackOrigin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Equals("Player")){
			trunkMan.AttackRight = false;
			trunkMan.AttackLeft = true;
		}

	}
}
