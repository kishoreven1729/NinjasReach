using UnityEngine;
using System.Collections;

public class CharacterControlNetwork : MonoBehaviour {
	
	private Vector3 _shurikenDirection;
	public Vector3 relativePos;
	public GameObject shurikenPrefab;
	public ShurikenNetwork shuriken;
	public Transform spawnPoint;
	private bool _shurikenInHand = true;
    private Animator _animator;

	// Use this for initialization
	void Start () {
        _animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		relativePos = Camera.main.WorldToScreenPoint(transform.position);
		//CheckInput();
	}

	void CheckInput()
	{
		if (_shurikenInHand)
		{
			GetShurikenDirection();
			CreateShuriken();
			SetShurikenInHand(false);
		}
		else
		{
			Teleport();
			SetShurikenInHand(true);
		}

	}

	void GetShurikenDirection()
	{
		_shurikenDirection = Input.mousePosition - relativePos;
	}

	void CreateShuriken()
	{
        _animator.SetTrigger("Throw");
		GameObject go = Instantiate(shurikenPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
		shuriken = go.GetComponent<ShurikenNetwork>();
		shuriken.Character = this;
		shuriken.Direction = _shurikenDirection;
	}

	void Teleport()
	{
        _animator.SetTrigger("Teleport");
		Vector3 shurikenPos = shuriken.transform.position;
		transform.position = shurikenPos;
		Destroy(shuriken.gameObject);
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawRay(transform.position, _shurikenDirection);
	}

	public void SetShurikenInHand(bool b)
	{
		_shurikenInHand = b;
	}
}
