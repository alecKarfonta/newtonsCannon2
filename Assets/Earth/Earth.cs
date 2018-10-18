using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour {

	Quaternion targetRotation;
	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.Euler (0, Random.Range(0, 360), 0);
		targetRotation = Quaternion.Euler (0, 360, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, Time.deltaTime * .007f );
	}
}
