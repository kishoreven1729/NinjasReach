using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public float movingSpeed;
	public float movingRange;
	private float direction = 1f;
	public float leftBound;
	public float rightBound;
	private float initPosX;

	// Use this for initialization
	void Start () {
		initPosX = transform.position.x;
		leftBound = initPosX - movingRange;
		rightBound = initPosX + movingRange;
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.right * direction * movingSpeed * Time.deltaTime);

		if (OutOfBound())
		{
			direction *= -1f;
		}
	}

	bool OutOfBound()
	{
		if (transform.position.x < leftBound && direction < 0)
			return true;
		if (transform.position.x > rightBound && direction > 0)
			return true;
		return false;
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(new Vector3(initPosX, transform.position.y, transform.position.z),
		                    new Vector3(2 * movingRange, 1f, 1f));
	}
}
