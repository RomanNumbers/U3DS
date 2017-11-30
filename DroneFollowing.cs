using UnityEngine;
using System.Collections;

public class droneFollow : MonoBehaviour {
	public Transform target;
	public Transform myTransform;

	public float moveSpeed = 3; 
	public float rotationSpeed = 3; 
//current transform data of this enemy

	void Awake()
	{
		myTransform = transform; //cache transform data for easy access/preformance
	}

	void Start()
	{
		target = GameObject.FindWithTag("drone").transform; //target the player

	}

	void Update () {
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);

		//move towards the player
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;


	}
}