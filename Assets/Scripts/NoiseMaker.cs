using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour {

	public bool isMakingNoise = false;
	private CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (cc.velocity.magnitude > 0) {
			isMakingNoise = true;
		} else {
			isMakingNoise = false;
		}
	}
}
