using UnityEngine;
using System.Collections;

public class RotateAroundBehavior : MonoBehaviour {

	public int numOrbiters;
	public GameObject sourceObject;
	public GameObject[] orbiters;
	private int orbitRadius = 3;

	// Use this for initialization
	void Start () {
		Init();
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < numOrbiters; i++){
			UpdateOrbiterPosition(i);
		}
	}

	void Init(){
		//set initial positions of balls
		//1 ball can be anywhere
		//2 balls should be opposite

		SetOrbiterPositions();
		Vector3 orbitPos = new Vector3(transform.position.x + orbitRadius, transform.position.y, transform.position.z);
		orbiters[0].GetComponent<Transform>().localPosition = orbitPos;
	}

	void SetOrbiterPositions(){
		float angleDiv = 360f / (float)numOrbiters;
	}

	void UpdateOrbiterPosition(int orbiter){
		orbiters[0].GetComponent<Transform>().RotateAround(sourceObject.transform.position, Vector3.forward, 100 * Time.deltaTime);
	}
}
