using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNoise : MonoBehaviour {

	public AudioClip doorSound;
	private Transform tf;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(){
		AudioSource.PlayClipAtPoint (doorSound, tf.position);
		Destroy (gameObject);
	}
}
