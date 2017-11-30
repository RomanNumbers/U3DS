using UnityEngine;
using System.Collections;

public class ShootFlares : MonoBehaviour {


		private Transform 	target;
		public float 		speed = 100;
		double 				destroytime = 1000.00f;



		//seek target
		public void seek(Transform _target)
		{
			target = _target;
		}

		//check for target collison

		void Update () {


			if (target == null ) 
			{
				Destroy (gameObject);
				return;
			}

			Vector3 dir = target.position - transform.position;
			float distanceThisFrame = speed * Time.deltaTime;

			if (dir.magnitude <= distanceThisFrame)
			{
				HitTarget ();
				return;
			}

			transform.Translate (dir.normalized * distanceThisFrame, Space.World);
			transform.LookAt (target);
			destroytime = destroytime - 1.00f;


			if (destroytime <= 0.0f) {

				Destroy (gameObject);
			}
		}



		void HitTarget()
		{
			Destroy (gameObject);
		}


	}
