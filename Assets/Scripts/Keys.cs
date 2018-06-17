using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Keys : MonoBehaviour {

	public bool greenKey = false;
	public bool purpleKey = false;
	public bool redKey = false;
	public bool goal = false;

	public Text greenKeyText;
	public Text purpleKeyText;
	public Text redKeyText;
	public Text goalText;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "gkey") {
			greenKey = true;
			greenKeyText.text = "Green Key Collected";
		} 
		if (other.gameObject.tag == "pkey") {
			purpleKey = true;
			purpleKeyText.text = "Purple Key Collected";
		} 
		if (other.gameObject.tag == "rkey") {
			redKey = true;
			redKeyText.text = "Red Key Collected";
		}
		if (other.gameObject.tag == "goal") {
			goal = true;
			goalText.text = "Goal Collected!!!\nReturn to the start";
		}
		if (other.gameObject.tag == "end") {
			SceneManager.LoadScene ("Victory");
		}
	}
}
