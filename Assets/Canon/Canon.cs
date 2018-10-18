using UnityEngine;
using System.Collections;

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
		// if space is down
		if (Input.GetKey (KeyCode.Space) || Input.GetButtonDown("Fire1")) {

			// if is not already firing, start firing
			if (!isFiring) {
				float force = GameObject.Find ("ForceSlider").GetComponent<UnityEngine.UI.Slider> ().value;
				Debug.Log ("Fire! "  + force);
				isFiring = true;
				// start animation
				animator.SetBool ("isFiring", true);
				// play audio
				audioSource.PlayOneShot (thwing);

				GameObject satelliteClone = (GameObject)Instantiate(satellite, transform.position + offset, transform.rotation);
				//satelliteClone.rigidbody.velocity = transform.forward * (speed * force);
				satelliteClone.GetComponent<Rigidbody>().velocity = transform.forward * (speed * force);
			}
		}
	}

}
