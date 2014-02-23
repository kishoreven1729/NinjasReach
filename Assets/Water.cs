using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

    public float movingSpeed;
	
	// Update is called once per frame
	void Update () {
	
        transform.Translate(Vector3.up * movingSpeed * Time.deltaTime);
	}
}
