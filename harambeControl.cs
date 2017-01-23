using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class harambeControl : MonoBehaviour {
	float curPosx;
	float curPosy;
	float curPosz;
	float curScalex;
	bool hasUsed;
	public static bool moving;
	bool paused;
	public static bool talking;
	public Text harambeDialog;
	public Image dialogBox;
	// Use this for initialization
	void Start () {
		curPosx = transform.position.x;
		curPosy = transform.position.y;
		curPosz = transform.position.z;
		curScalex = transform.localScale.x;
		talking = false;
		paused = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (talking) {
			dialogBox.enabled = true;
			harambeDialog.enabled = true;

			if(Input.GetKeyDown(KeyCode.E)){
				harambeDialog.text = "There is a monster at the end of this cave. Use the [B] key to use a magical fireball to deflect";
				paused = false;
			}
			if (paused) {
				pauseMenu.bypass = true;
				pauseMenu.paused = true;
				//Time.timeScale = 0;
				//Debug.Log ("Testing pause");
			} else {
				pauseMenu.paused = false;
				pauseMenu.bypass = false;
			}

		} else {
			dialogBox.enabled = false;
			harambeDialog.enabled = false;
		}

	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Equals("Player") == true){
			transform.localScale = new Vector3 (-curScalex, transform.localScale.y, transform.localScale.z);
			talking = true;
			paused = true;
		}


	}
		
}
