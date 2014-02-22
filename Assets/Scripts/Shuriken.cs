using UnityEngine;
using System.Collections;

public class Shuriken : MonoBehaviour {

	public Vector3 direction;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = direction * speed;
	}
}
