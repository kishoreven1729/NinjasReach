using UnityEngine;
using System.Collections;

public class BreakablePlatform : MonoBehaviour
{

    public float lifeTime;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("Break");
        }
    }

    IEnumerator Break()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(collider2D);

        // TODO: play animation

        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }
}
