using UnityEngine;
using System.Collections;

public class material : MonoBehaviour {

	// Use this for initialization
	public Texture text;
	public Material mat;
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		mat.mainTexture=text;
	}
}
