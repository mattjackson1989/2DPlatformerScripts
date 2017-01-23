using UnityEngine;
using System.Collections;

public class cloudEnd : MonoBehaviour {
	public GameObject cloudOrigin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals ("cloud")) {
			col.transform.position = new Vector3 (cloudOrigin.transform.position.x, transform.position.y, transform.position.z);

		}


	}
}
