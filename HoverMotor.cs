using UnityEngine;
using System.Collections;

public class HoverMotor : MonoBehaviour {
	public Vector3 thrustOrientation = Vector3.forward;

	public Transform ColOBJ;

	public float speed =90.0f;
	public float hoverForce = 65f;
	public float hoverHeight = 2.5f;

	private float powerInput;
	private Rigidbody thisR;

	void Awake() {
		thisR = GetComponent<Rigidbody>();
	}
	
	void Update () {

			powerInput = Input.GetAxis ("Vertical");
		

	}
	void FixedUpdate()
	{
		Ray ray = new Ray (transform.position,-Vector3.up);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit,hoverHeight))
		{
			float proportionalHeight = (hoverHeight-hit.distance)/hoverHeight;
			Vector3 appliedHoverForce = Vector3.up *proportionalHeight*hoverForce;
			thisR.AddForce(appliedHoverForce,ForceMode.Acceleration);
		}
		thisR.AddRelativeForce (ColOBJ.transform.forward*powerInput*speed);
	}
}