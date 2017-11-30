using UnityEngine;
using System.Collections;

public class CopyRotationSmooth : MonoBehaviour {
	public Transform Target;
	public float smoothCoefficient;
	void LateUpdate()
	{
		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Target.transform.rotation, smoothCoefficient*Time.deltaTime);
	}
}
