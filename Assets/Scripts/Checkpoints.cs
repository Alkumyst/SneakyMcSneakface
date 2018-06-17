using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {

	private Transform tf;
	public static Vector3 respawnPoint;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(){
		//set respawn
		respawnPoint = tf.position;
		//remove object from world
		Destroy(gameObject);
	}
}
