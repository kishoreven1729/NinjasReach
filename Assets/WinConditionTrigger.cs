using UnityEngine;
using System.Collections;

public class WinConditionTrigger : MonoBehaviour {

    public enum TriggerType
    {
        Win,
        Lose
    }

    public TriggerType type;

    void OnTriggerEnter2D(Collider2D other) 
	{   
        if (other.gameObject.tag == "Player1")
        {
			GUIManager.instance.ServerWins();
        }
		else if(other.gameObject.tag == "Player2")
		{
			GUIManager.instance.ClientWins();
		}
    }

}
