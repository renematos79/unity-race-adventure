using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MotorController : MonoBehaviour {

	private WheelJoint2D Wheel1;
	private WheelJoint2D Wheel2;
	public float Speed = 300;
	public bool Auto = false;

	private JointMotor2D Motor1;
	private JointMotor2D Motor2;

	public bool InMovement{
		get
		{
			return Wheel1.useMotor;
		}		
	}

	private AudioSource AudioSource;

	// Use this for initialization
	void Start () {
		Wheel1 = GetComponents<WheelJoint2D> ().FirstOrDefault();
		Wheel2 = GetComponents<WheelJoint2D> ().LastOrDefault();

		AudioSource = GetComponent<AudioSource> ();

		Motor1 = Wheel1.motor;
		Motor2 = Wheel2.motor;
	}
	
	// Update is called once per frame
	void Update () {
		var useMotor = false;
		var direction = 0;

		if (Input.GetKey (KeyCode.RightArrow) || Auto) {
			useMotor = true;
			direction = -1;
			if (AudioSource.isPlaying == false) {
				AudioSource.Play ();
			}
		}

		if (Input.GetKey (KeyCode.LeftArrow) && Auto == false) {
			useMotor = true;
			direction = +1;
			AudioSource.Stop ();
		}

		Motor1.motorSpeed = (direction) * Mathf.Abs (Speed);
		Motor2.motorSpeed = (direction) * Mathf.Abs (Speed);

		Wheel1.motor = Motor1;	
		Wheel2.motor = Motor2;

		Wheel1.useMotor = useMotor;
		Wheel2.useMotor = useMotor;
	}
}
