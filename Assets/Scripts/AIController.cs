using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AIController : MonoBehaviour {
	public Vector3 pointA;
	public Vector3 pointB;
	public float hearingRadius = 10.0f;
	public float viewDistance = 15.0f;
	public float FOV = 60.0f;
	private AudioSource audsrc;
	public AudioClip hearSomething;
	public AudioClip seeSomething;
	//private Transform tf;

	public Text alertTextbox;

	public GameObject target;

	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		audsrc = GetComponent<AudioSource> ();
		//tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		alertTextbox.text = "";

		if (CanHear (target)) {
			alertTextbox.text = "?";
			if (!audsrc.isPlaying) {
				if (CanSee (target)) {
					//do nothing
				} else {
					audsrc.clip = hearSomething;
					audsrc.Play ();
				}
			}
		}
		if (CanSee (target)) {
			alertTextbox.text = "!";
			if (!audsrc.isPlaying) {
				audsrc.clip = seeSomething;
				audsrc.Play ();
			}
			agent.SetDestination (target.transform.position);
		} else {
			agent.SetDestination (transform.position);
		}

		//todo remove these two and make AI pace back and forth~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		if (Input.GetKeyDown (KeyCode.T)) {
			agent.SetDestination (pointA);
		}
		if (Input.GetKeyDown (KeyCode.Y)) {
			agent.SetDestination (pointB);
		}
		//todo make AI pace back and forth~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		if (transform.position == pointA) {
			agent.SetDestination (pointB);
		}
		if (transform.position == pointB) {
			agent.SetDestination (pointA);
		}
	}

	bool CanHear(GameObject other){
		//check if the other thing is making noise
		NoiseMaker otherNM = other.GetComponent<NoiseMaker>();
		if (otherNM.isMakingNoise) {
			//check if the other thing is close enough to be heard
			if (Vector3.Distance (transform.position, other.transform.position) <= hearingRadius) {
				//then say "yes" we can hear them (true)
				return true;
			}
		}
		//If we made it this far, and we didn't return true, then return false
		return false;
	}

	bool CanSee(GameObject other){
		//check for view distance
		//find the vector to my target
		Vector3 vectorToTarget;
		vectorToTarget = other.transform.position - transform.position;

		//check for Field Of View
		float angleToTarget=Vector3.Angle(transform.forward, vectorToTarget);
		if (angleToTarget <= FOV) {
			//check line of sight
			RaycastHit rcData;
			if (Physics.Raycast (transform.position, vectorToTarget, out rcData, viewDistance)) {
				//we hit something
				if (rcData.collider.gameObject == other) {
					//I can see it
					return true;
				}
			}
		}
	//if I make it this far, and hav't returned true, the return false
	return false;
	}

}
