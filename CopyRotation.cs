using UnityEngine;
using System.Collections;

public class CopyRotation : MonoBehaviour {
	public Transform Target;

	void LateUpdate()
	{
		this.transform.rotation = Target.transform.rotation;
	}
}
