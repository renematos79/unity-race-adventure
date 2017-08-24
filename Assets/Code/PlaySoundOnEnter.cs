using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlaySoundOnEnter : MonoBehaviour {

	private AudioSource AudioSrc;
	public List<string> PlayOnTags= new List<string>();

	// Use this for initialization
	void Start () {
		AudioSrc = GetComponent<AudioSource> ();
	}

	void PlaySound(){
		if (AudioSrc != null && AudioSrc.isPlaying == false) {
			AudioSrc.Play ();
		}
	}

	void StopSound(){
		if (AudioSrc != null) {
			AudioSrc.Stop ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool ContainsTag(GameObject gameObject){
		if (gameObject == null || string.IsNullOrEmpty (gameObject.tag)) {
			return false;
		}
		return PlayOnTags.Any(a => a == gameObject.tag);
	}


	void OnTriggerEnter2D(Collider2D source){
		if (ContainsTag(source.gameObject)) {
			PlaySound ();
		}
	}

	void OnTriggerStay2D(Collider2D source){
		if (ContainsTag(source.gameObject)) {
			var motor = source.gameObject.GetComponent<MotorController> ();
			if (motor == null) {
				motor = source.gameObject.GetComponentInParent<MotorController>();
			}

			if (motor != null) {
				if (motor.InMovement) {
					PlaySound ();	
				} 
			} 
		}
	}

	void OnTriggerExit2D(Collider2D source){
		if (ContainsTag(source.gameObject)) {
			StopSound ();
		}
	}

	void OnCollisionEnter2D(Collision2D source){
		if (ContainsTag(source.gameObject)) {
			PlaySound ();
		}
	}

	void OnCollisionExit2D(Collision2D source){
		if (ContainsTag(source.gameObject)) {
			StopSound ();
		}
	}
}
