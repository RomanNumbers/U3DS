using UnityEngine;
using System.Collections;

public class FlareCMS : MonoBehaviour {

	private Transform 		target;
	public float 			range = 100f;
	public string 			TargetTag = "Missile"; //giving it a tag to identiy what to track
	public Transform 		parttoRotate; // the part which actually rotates
	public float 			turnspeed = 10f;
	public float 			fireRate = 3f;
	private float 			fireCountdown = 0;
	public GameObject 		rocketPrefab;
	public Transform		firePoint;
	public AudioSource 		FlareLaunchAudio;



	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget(){

		GameObject[] enemies = GameObject.FindGameObjectsWithTag (TargetTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestenemy = null;

		foreach (GameObject enemy in enemies) {
			float distanceToenemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (distanceToenemy < shortestDistance) {
				shortestDistance = distanceToenemy;
				nearestenemy = enemy;
			}

		}

		if (nearestenemy != null && shortestDistance <= range) {
			target = nearestenemy.transform;
		} else
			target = null;


	}

	void Update () {

		if (target == null)
			return;

		Vector3 dir = (target.position - transform.position);
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = lookRotation.eulerAngles;
		parttoRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

		if (fireCountdown <= 0f) {
			Shoot ();
			fireCountdown = 3f / fireRate;
		}

		fireCountdown -= Time.deltaTime;
	}

	void Shoot(){


		GameObject rckt = (GameObject) Instantiate (rocketPrefab, firePoint.position, firePoint.rotation);
		FireFlares rockt = rckt.GetComponent <FireFlares>();
		AudioSource FlareLaunchAudio = GetComponent<AudioSource> ();
		FlareLaunchAudio.Play ();
		if (rockt != null) {
			rockt.seek (target);
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
