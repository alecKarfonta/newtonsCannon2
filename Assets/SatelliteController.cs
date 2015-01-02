using UnityEngine;
using System.Collections;

public class SatelliteController : MonoBehaviour {

	Vector3 gravityPoint = new Vector3(0,0,0);
	float rotationsPerMinute = 10;
	Quaternion targetRotation;

	// Use this for initialization
	void Start () {
		targetRotation = Quaternion.Euler (0, 360, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rigidbody.AddForce((gravityPoint - transform.position).normalized );
		//transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, Time.deltaTime * 6f );
		transform.Rotate(0,0,6.0f*rotationsPerMinute*Time.deltaTime);
	}
}
