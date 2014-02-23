using UnityEngine;
using System.Collections;

public class WinConditionTrigger : MonoBehaviour {

    public enum TriggerType
    {
        Win,
        Lose
    }

    public TriggerType type;

    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.tag == "Player")
        {
            if (type == TriggerType.Win)
                GameManager.Instance.GameWin();
            else
                GameManager.Instance.GameOver();
        }
    }

}
