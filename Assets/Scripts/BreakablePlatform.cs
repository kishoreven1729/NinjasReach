using UnityEngine;
using System.Collections;

public class BreakablePlatform : MonoBehaviour
{
    public float lifeTime;
    public GameObject realCollider;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("Break");
        }
    }

    IEnumerator Break()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(realCollider);

        // TODO: play animation
        _animator.SetTrigger("Breaking");

        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }
}
