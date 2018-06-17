using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DieOnContact : MonoBehaviour {

	private int live;

	public Text livesTxt;

	// Use this for initialization
	void Start () {
		Checkpoints.respawnPoint = transform.position;
		StrtGm ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "AI") {
			Die ();
		}
	}

	void Die(){
		//subtract from lives


		decreaseLives();
		//if all lives gone game over
		if (live < 0) {
			SceneManager.LoadScene ("Failure");
		}
		//otherwise teleport to checkpoint
		transform.position = Checkpoints.respawnPoint;
	}

	void StrtGm(){
		live = 3;
		livesTxt.text = "Lives: " + live;
	}

	void decreaseLives(){
		live--;
		livesTxt.text = "Lives: " + live;
	}
}
