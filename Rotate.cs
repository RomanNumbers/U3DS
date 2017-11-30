using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	const float rotationBias = 1;
	 readonly Vector3 rotation = new Vector3 (0, 0, 1) * rotationBias;
	// Use this for initialization

	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (rotation);
	}
}
