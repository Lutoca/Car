using UnityEngine;
using System.Collections;

public class VehiculeControl : MonoBehaviour {

	public class Buggy : MonoBehaviour
	{
		//les colliders des roues
		public WheelCollider frontWheel1;
		public WheelCollider frontWheel2;
		public WheelCollider rearWheel1;
		public WheelCollider rearWheel2;
		//Les mesh des roues pour les faire tourner
		public Transform wheelFL;
		public Transform wheelFR;
		public Transform wheelRL;
		public Transform wheelRR;

		public float steerMax = 20f;
		public float motorMax = 10f;
		public float brakeMax = 100f;

		private float steer = 0f;
		private float motor = 0f;
		private float brake = 0f;

		public float speed = 1.5f;
		void CheckKeys()
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{


				transform.position += Vector3.forward * speed;
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.position += Vector3.back * speed;
			}
			if (Input.GetKey(KeyCode.UpArrow))
			{

				transform.position += Vector3.right * speed;
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				transform.position += Vector3.left * speed;
			}


		}


		// Use this for initialization
		void Start()
		{
			rigidbody.centerOfMass += new Vector3(0f, -0.5f, 0f);
		}

		// Update is called once per frame
		void Update()
		{

		}

		void FixedUpdate()
		{
			CheckKeys();
			steer = Mathf.Clamp(Input.GetAxis("Horizontal"), -1, 1);
			motor = Mathf.Clamp(Input.GetAxis("Vertical"), 0, 1);
			brake = -1 * Mathf.Clamp(Input.GetAxis("Vertical"), -1, 0);

			rearWheel1.motorTorque = motorMax * motor;
			rearWheel2.motorTorque = motorMax * motor;
			rearWheel1.brakeTorque = brakeMax * brake;
			rearWheel2.brakeTorque = brakeMax * brake;

			frontWheel1.steerAngle = steerMax * steer;
			frontWheel2.steerAngle = steerMax * steer;
			Vector3 frl = new Vector3(wheelFR.localEulerAngles.x, steerMax * steer, wheelFR.localEulerAngles.z);
			wheelFL.localEulerAngles = frl;
			Vector3 frr = new Vector3(wheelFR.localEulerAngles.x, steerMax * steer, wheelFR.localEulerAngles.z);
			wheelFR.localEulerAngles = frr;

			wheelFR.Rotate(frontWheel1.rpm * -6 * Time.deltaTime, 0, 0);
			wheelFL.Rotate(frontWheel2.rpm * -6 * Time.deltaTime, 0, 0);
			wheelRR.Rotate(rearWheel1.rpm * -6 * Time.deltaTime, 0, 0);
			wheelRL.Rotate(rearWheel2.rpm * -6 * Time.deltaTime, 0, 0);
		}

	}
	

}
