using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Player")
		{
			GameManager.Instance.GameOver();
		}
	}
}
