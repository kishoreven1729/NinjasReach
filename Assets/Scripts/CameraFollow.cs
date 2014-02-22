using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public Vector3 relativePos;
	public float smoothFactor;
    private float initPosX;
	// Use this for initialization
	void Start () {
//		relativePos = transform.position - target.position;
//        initPosX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
            return;
        Vector3 newPos = Vector3.Lerp(transform.position, target.position + relativePos, smoothFactor * Time.deltaTime);
//		transform.position = Vector3.Lerp(transform.position, target.position + relativePos, smoothFactor * Time.deltaTime);
        newPos.x = initPosX;
        transform.position = newPos;
	}

    public void SetTarget(Transform t)
    {
        target = t;
        relativePos = transform.position - t.position;
        initPosX = transform.position.x;
    }
}
