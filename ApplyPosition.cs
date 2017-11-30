using UnityEngine;
using System.Collections;

public class ApplyPosition : MonoBehaviour {
	public Transform TargetRigidbody;
	void LateUpdate()
	{
		this.transform.position = TargetRigidbody.transform.position;
	}
}

