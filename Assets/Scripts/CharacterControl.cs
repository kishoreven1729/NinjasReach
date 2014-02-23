using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
	
	private Vector3 _shurikenDirection;
	public Vector3 relativePos;
	public GameObject shurikenPrefab;
	public Shuriken shuriken;
	public Transform spawnPoint;
	private bool _shurikenInHand = true;
    private Animator _animator;
    private Vector3 teleportPos;

    public AudioClip teleportSFX;

	// Use this for initialization
	void Start () {
        GameManager.Instance.player1 = this;
        _animator = GetComponentInChildren<Animator>();
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
	}

	void GetShurikenDirection()
	{
		_shurikenDirection = (Input.mousePosition - relativePos).normalized;
	}

	void CreateShuriken()
	{
        _animator.SetTrigger("Throw");
		GameObject go = Instantiate(shurikenPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
		shuriken = go.GetComponent<Shuriken>();
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.position = new Vector3(collision.gameObject.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
