using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameContr : MonoBehaviour {

	Keys otherComponent;
	private GameContr gamemanager;

	// Use this for initialization
	void Start () {
		otherComponent = GetComponent<Keys> ();

		DontDestroyOnLoad (this);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}


}
