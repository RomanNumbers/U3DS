using UnityEngine;
using System.Collections;

public class PlayerCounterMeasures : MonoBehaviour {

	private Transform target;
	public float range = 100f;
	public string enemyTag = "enemy"; //giving it a tag to identiy what to track
	public Transform parttoRotate; // the part which actually rotates
	public float turnspeed = 10f;
	public float fireRate = 3f;
	private float fireCountdown = 0;
	public GameObject rocketPrefab;
	public Transform firePoint;



	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget(){

		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
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
			//AudioSource audio = GetComponent <AudioSource> ();
			//audio.Play();
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
		rocket rockt = rckt.GetComponent <rocket>();
		if (rockt != null) {
			rockt.seek (target);
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
