using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {
	
	public AudioClip PlayerDestroy;
	public ParticleSystem PlayerShards;
	public ParticleSystem ExplodeFlame;



	void Update () {

		int speed = 120;
		int rotateSpeed = 60;

		var transAmount = speed * Time.deltaTime;
		var rotateAmount = rotateSpeed * Time.deltaTime;

		if (Input.GetKey("w")) {
			transform.Translate(0, transAmount, 0);
		}
		if (Input.GetKey("s")) {
			transform.Translate(0, -transAmount, 0);
		}
		/*if (Input.GetKey("a")) {
			transform.Rotate(0, -rotateAmount, 0);
		}
		if (Input.GetKey("d")) {
			transform.Rotate(0, rotateAmount, 0);
		}*/

		if (Input.GetKey("a")) {
			transform.Rotate(0, 0, rotateAmount);
		}

		if (Input.GetKey("d")) {
			transform.Rotate(0,0, -rotateAmount);
		}


	}



	IEnumerator OnTriggerEnter (Collider other)
	{



		if (other.gameObject.tag == "Missile") {
			//MeshRenderer M = GetComponent <MeshRenderer>();
			//M.enabled = false;
			//PlayerShards.Play ();
			//ExplodeFlame.Play ();
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
			yield return new WaitForSeconds(audio.clip.length);
			Destroy (this.gameObject);
			//Application.LoadLevel ("Outro");


		}

	}




		
}
