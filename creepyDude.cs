using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class creepyDude : MonoBehaviour {
	public Text dudeDialog;
	public Image dialogBox;
	private int dialog_count;

	// Use this for initialization
	void Start () {
		dialog_count = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Equals("Player")){
			this.gameObject.GetComponent<SpriteRenderer> ().flipX = true;
			dialogBox.enabled = true;
			dudeDialog.enabled = true;
		}

	}
	void OnTriggerStay2D(Collider2D col){
		if (Input.GetKeyDown (KeyCode.E)) {
			switch(dialog_count){
			case 0:
				dudeDialog.text = "HARRIS: This is the Arcadian forest: grave to those who dream... [E]";
				++dialog_count;
				break;
			case 1:
				dudeDialog.text = "HARRIS: Let me give you some helpful hints: [E]";
				++dialog_count;
				break;
			case 2:
				dudeDialog.text = "HARRIS: Use [B] to cast a fireball from the staff I gave you " +
					"[E]";
				++dialog_count;	
				break;
			case 3:
				dudeDialog.text = "HARRIS: Use [SHIFT] to run super fast with the boots I gave you " +
					"[E]";
				++dialog_count;	
				break;
			case 4:
				dudeDialog.text = "HARRIS: To escape this world you must find Terribithia, Chalis of the Garden [E]"; 
				++dialog_count;	
				break;
			case 5:
				dudeDialog.text = "HARRIS: OH! One last thing! Our animals in this forest our possessed by Malarith. Try not to harm them...[END]";
				dialog_count = 0;
				break;
			}
		}

	}
	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag.Equals("Player")){
			dialogBox.enabled = false;
			dudeDialog.enabled = false;
			this.gameObject.GetComponent<SpriteRenderer> ().flipX = false;
		}

	}
}
