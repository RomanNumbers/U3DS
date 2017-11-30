using UnityEngine;
using System.Collections;


public class FlareDestroy : MonoBehaviour
{
	
	public AudioClip a;

	void OnTriggerEnter (Collider other)
	{

		if (other.gameObject.tag == "Missile") {
			Destroy (this.gameObject);
		}

	}
}