using UnityEngine;
using System.Collections;

public class fireparticlesystem : MonoBehaviour {


	public ParticleSystem sonic;

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("x"))
		{
			sonic.Play ();

		}

		if (Input.GetKeyUp("x"))
		{
			sonic.Stop ();

		}
			

	}
}
