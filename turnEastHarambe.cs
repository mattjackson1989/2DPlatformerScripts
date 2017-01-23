using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class turnEastHarambe : MonoBehaviour {
	public GameObject harambe;
	public Text harambeText;
	public Image dialogBox;

	float curScalex;

	void Start () {
		curScalex = transform.localScale.x;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Equals("Player") == true){
			harambe.transform.localScale = new Vector3 (curScalex, transform.localScale.y, transform.localScale.z);
			harambeText.enabled = false;
			dialogBox.enabled = false;
			harambeControl.talking = false;
		}


	}

}
