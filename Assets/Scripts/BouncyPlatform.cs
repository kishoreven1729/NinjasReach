using UnityEngine;
using System.Collections;

public class BouncyPlatform : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shuriken")
        {
            Shuriken shuriken = collision.gameObject.GetComponent<Shuriken>();
            shuriken.Direction = collision.contacts[0].normal;
        }
    }
}
