using UnityEngine;
using System.Collections;

public class materialStereo : MonoBehaviour {

	// Use this for initialization
	public Texture text;
	public Material mat,mat2;
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		mat.mainTexture=text;
		mat2.mainTexture=text;
	}
}
