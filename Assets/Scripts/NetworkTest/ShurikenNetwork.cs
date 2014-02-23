using UnityEngine;
using System.Collections;

public class ShurikenNetwork : MonoBehaviour {

	private Vector3 _direction;
	public float speed;
	public float rotationSpeed;
	private CharacterControlNetwork _character;

	public Vector3 Direction {
		get {
			return _direction;
		}
		set {
			_direction = value;
		}
	}

	public CharacterControlNetwork Character {
		get {
			return _character;
		}
		set {
			_character = value;
		}
	}

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = _direction * speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
		CheckBoundary();
	}

	void CheckBoundary()
	{
		if (GameManager.Instance.OutOfBoundary(transform.position))
		{
			Network.Destroy(gameObject);
			_character.SetShurikenInHand(true);
		}
	}
}
