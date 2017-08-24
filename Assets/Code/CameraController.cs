using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform Follow;
	public float MinValue = 0;
	public float MaxValue = float.MaxValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var x = Mathf.Clamp (Follow.position.x, MinValue, MaxValue);
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);
	}
}
