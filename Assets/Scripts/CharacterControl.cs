using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

	private Vector3 _shurikenDirection;
	public Vector3 relativePos;
	public GameObject shurikenPrefab;
	public Shuriken shuriken;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		relativePos = Camera.main.WorldToScreenPoint(transform.position);
		CheckInput();


	}

	void CheckInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_shurikenDirection = Input.mousePosition - relativePos;
			print (Input.mousePosition);
			print ("transform.position:" + relativePos);
		}
	}

	void CreateShuriken()
	{
		GameObject go = Instantiate(shurikenPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
		shuriken = go.GetComponent<Shuriken>();

	}

	void OnDrawGizmos()
	{
		Gizmos.DrawRay(transform.position, _shurikenDirection);
	}
}
