using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		Keys otherComponent;
		otherComponent = other.GetComponent<Keys> ();
		if (gameObject.tag == "gdoor" && otherComponent.greenKey == true) {
			Destroy (gameObject);
		}
		if (gameObject.tag == "pdoor" && otherComponent.purpleKey == true) {
			Destroy (gameObject);
		}
		if (gameObject.tag == "rdoor" && otherComponent.redKey == true) {
			Destroy (gameObject);
		}
	}
}
