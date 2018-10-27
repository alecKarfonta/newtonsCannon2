using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public GameObject moon;


	// Use this for initialization
	void Start ()
    {
        moon.GetComponent<Rigidbody>().velocity = transform.forward * 100;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
