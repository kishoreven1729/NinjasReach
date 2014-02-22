using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public Vector3 relativePos;
	public float smoothFactor;
	// Use this for initialization
	void Start () {
		relativePos = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, target.position + relativePos, smoothFactor * Time.deltaTime);
	}
}
