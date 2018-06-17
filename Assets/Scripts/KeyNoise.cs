using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyNoise : MonoBehaviour {

	public AudioClip keySound;
	private Transform tf;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(){
		AudioSource.PlayClipAtPoint (keySound, tf.position);
		Destroy (gameObject);
	}
}
