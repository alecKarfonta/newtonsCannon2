using UnityEngine;
using System.Collections;

// TODO: Add friction to earth so that while rotating the fallen satellites stay in place

public class Canon : MonoBehaviour {
	public GameObject satellite;
	AudioSource audioSource;
	public AudioClip thwing;
	Animator animator;
	float speed = .2f;
	Vector3 offset = new Vector3(.15f, 0 , -.15f);

	double fireTimerLength = .25,
			fireTimer = 0.0;
	bool isFiring = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		// update firing timer
		if (isFiring) {
			fireTimer += Time.deltaTime;
			if (fireTimer >= fireTimerLength) {
				fireTimer = 0.0;
				isFiring = false;
				animator.SetBool ("isFiring", false);
			}
		}
		// If user hit space or clicked the mouse
		if (Input.GetKey (KeyCode.Space) || Input.GetButtonDown("Fire1")) {

			// if is not already firing, start firing
			if (!isFiring) {
				// Get force value from slider
				float force = GameObject.Find ("ForceSlider").GetComponent<UnityEngine.UI.Slider> ().value;
				Debug.Log ("Fire! "  + force);
				isFiring = true;
				// Start cannon animation
				animator.SetBool ("isFiring", true);

				// TODO: Set volume based on force

				// play audio
				audioSource.PlayOneShot (thwing);

				// Instantiate new satellite
				GameObject satelliteClone = (GameObject)Instantiate(satellite, transform.position + offset, transform.rotation);
				// Set velocty on satellite
				satelliteClone.GetComponent<Rigidbody>().velocity = transform.forward * (speed * force);
			}
		}
	}

}
