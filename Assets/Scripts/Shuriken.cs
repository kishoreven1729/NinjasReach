using UnityEngine;
using System.Collections;

public class Shuriken : MonoBehaviour
{

    private Vector3 _direction;
    public float speed;
    public float rotationSpeed;
    private CharacterControl _character;
    public AudioClip launchSFX;
    public AudioClip bounceSFX;
    public AudioClip disappearSFX;
    public GameObject disappearParticlePrefab;
    public float lifeTimeAfterBounce;
    private bool _isBeingDestroyed = false;
    private bool _isPlayingBouncingSFX = false;

    public Vector3 Direction
    {
        get
        {
            return _direction;
        }
        set
        {
            _direction = value;
        }
    }

    public CharacterControl Character
    {
        get
        {
            return _character;
        }
        set
        {
            _character = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        rigidbody2D.velocity = _direction * speed * Time.deltaTime;
        AudioManager.Instance.PlaySound(launchSFX);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        CheckBoundary();
    }

    void CheckBoundary()
    {
        if (GameManager.Instance.OutOfBoundary(transform.position))
        {
            DestroyShuriken();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Bouncy")
        {
            if (!_isPlayingBouncingSFX)
            {
                audio.Stop();
                AudioManager.Instance.PlaySound(bounceSFX);
                _isPlayingBouncingSFX = true;
            }
            rigidbody2D.gravityScale = 3f;
            if (!_isBeingDestroyed)
            {
                StartCoroutine("Disappear");
            }
        }
    }

    IEnumerator Disappear()
    {
        _isBeingDestroyed = true;
        yield return new WaitForSeconds(lifeTimeAfterBounce);
        AudioManager.Instance.PlaySound(disappearSFX);
        DestroyShuriken();
        if (disappearParticlePrefab != null)
            Instantiate(disappearParticlePrefab, transform.position, Quaternion.identity);
    }

    void DestroyShuriken()
    {
        Destroy(gameObject);
        _character.SetShurikenInHand(true);
    }

}



