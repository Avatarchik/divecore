using UnityEngine;
using System.Collections;

public class SphereRepositionning : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//Vector3 pos=transform.position;
		//Vector3 rot=transform.rotation.eulerAngles;

		transform.rotation= Quaternion.Euler( 270,0,0);
	}
}
