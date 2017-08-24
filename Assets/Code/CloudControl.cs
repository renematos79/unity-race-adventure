using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour {

	public Vector2 Increment = new Vector2();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Increment.x * Time.deltaTime, Increment.y * Time.deltaTime, 0f);
	}
}
