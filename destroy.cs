using UnityEngine;
using System.Collections;


public class destroy : MonoBehaviour
{

	public AudioClip MissileDestroy;

	void OnTriggerEnter (Collider other)
	{



		if (other.gameObject.tag == "flare") {
			//MeshRenderer M = GetComponent <MeshRenderer>();
			//M.enabled = false;
			//PlayerShards.Play ();
			//ExplodeFlame.Play ();
			//AudioSource audio = GetComponent<AudioSource> ();
			//audio.Play ();
			//yield return new WaitForSeconds (audio.clip.length);
			Destroy (this.gameObject);
			//Application.LoadLevel ("Outro");

		}

	}
}