using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

    public float movingSpeed;
	
	// Update is called once per frame
	void Update () {
	
        transform.Translate(Vector3.up * movingSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) 
	{   
		if (other.gameObject.tag == "Player1")
		{
			GUIManager.instance.ClientWins();
		}
		else if(other.gameObject.tag == "Player2")
		{
			GUIManager.instance.ServerWins();
		}
	}
}
