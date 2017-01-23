using UnityEngine;
using System.Collections;

public class attackFire : MonoBehaviour {
	//public GameObject fireOrigin;

	public GameObject prefabProjectile;
	int cycles;
	//public GameObject origin;
	// Use this for initialization
	void Start () {
		//fireOrigin.transform.position = this.transform.position;
		cycles = 0;
	}
	
	// Update is called once per frame
	void Update () {
		attack ();
	}
	void attack(){
		if (cycles > 200) {
			GameObject projectile = Instantiate (prefabProjectile, this.transform.position, this.transform.rotation) as GameObject;
			cycles = 0;
		}
		cycles++;
	}
}
