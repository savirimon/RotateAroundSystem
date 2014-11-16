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
			if(i < orbiters.Length){
				UpdateOrbiterPosition(i);
			}
		}
	}

	void Init(){
		//set initial positions of balls
		//1 ball can be anywhere
		//2 balls should be opposite

		SetOrbiterPositions();
	}

	void AddOrbiter(){
		numOrbiters++;
		SetOrbiterPositions();
	}

	void RemoveOrbiter(){
		if(numOrbiters > 0){
			numOrbiters--;
		}
		SetOrbiterPositions();
	}

	void SetOrbiterPositions(){
		float angleDiv = 360f / (float)numOrbiters;

		if(numOrbiters > orbiters.Length){
			angleDiv = 360f / orbiters.Length;
		}

		Vector3 orbitPos = new Vector3(transform.position.x + orbitRadius, transform.position.y, transform.position.z);
		for(int i = 0; i < numOrbiters; i++){
			if (i < orbiters.Length){
				orbiters[i].GetComponent<Transform>().localPosition = orbitPos;	//move to initial pos
				orbiters[i].GetComponent<Transform>().RotateAround(sourceObject.transform.position, Vector3.forward, angleDiv * i);//rotate
			}
			
		}
	}

	void UpdateOrbiterPosition(int orbiter){
		orbiters[orbiter].GetComponent<Transform>().RotateAround(sourceObject.transform.position, Vector3.forward, 100 * Time.deltaTime);
	}
}
