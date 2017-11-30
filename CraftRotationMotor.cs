using UnityEngine;
using System.Collections;

public class CraftRotationMotor : MonoBehaviour {

	public float scanDistance;
	public float smoothingCoefficient;
	public Vector3 steerOrientation = Vector3.up;
	private bool isControlableRec;
	public Transform MeshObject;

	public float steerMultiplier;
	private float Direction;
	private float TurnCoefficient;
	private Vector3 currentNormal = Vector3.up;

	public Transform FL;
	public Transform FR;
	public Transform RL;
	public Transform RR;

	private RaycastHit fl;
	private RaycastHit fr;
	private RaycastHit rl;
	private RaycastHit rr;

	private Vector3 upDireccion;
	
	void Start () {
		GetComponent<Rigidbody>().freezeRotation = true;
	}

	void Update () {

		Physics.Raycast(FL.position + Vector3.up, Vector3.down, out fl);
		Physics.Raycast(FR.position + Vector3.up, Vector3.down, out fr);
		Physics.Raycast(RL.position + Vector3.up, Vector3.down, out rl);
		Physics.Raycast(RR.position + Vector3.up, Vector3.down, out rr);

		upDireccion = (Vector3.Cross(rr.point - Vector3.up, rl.point - Vector3.up) +
		       		   Vector3.Cross(rl.point - Vector3.up, fl.point - Vector3.up) +
		   		       Vector3.Cross(fl.point - Vector3.up, fr.point - Vector3.up) +
		   		       Vector3.Cross(fr.point - Vector3.up, rr.point - Vector3.up)
		         	   ).normalized;

		TurnCoefficient = Input.GetAxis("Horizontal") * steerMultiplier * Time.deltaTime;
		Direction = (Direction + TurnCoefficient) % 360;
		RaycastHit hit;
		if(Physics.Raycast(this.transform.position,-this.transform.up,out hit,scanDistance))
		{
			currentNormal = Vector3.Slerp(currentNormal,upDireccion,Time.deltaTime*smoothingCoefficient);
			Quaternion rot = Quaternion.FromToRotation(Vector3.up,currentNormal);
			MeshObject.transform.rotation = rot*Quaternion.Euler(0,Direction,0);
		}
	}
}
