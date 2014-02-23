using UnityEngine;
using System.Collections;

public class NinjaSpriteControl : MonoBehaviour {

    public CharacterControl cc;
    public bool hasAnimationEnded;
	// Use this for initialization
	void Start () {
        hasAnimationEnded = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void TeleportDisappearComplete() {
        print("TeleportDisappearComplete: " + hasAnimationEnded);

        if(hasAnimationEnded == false)
        {
            cc.OnTeleportCompleted();
            hasAnimationEnded = true;
        }
        else
        {
            hasAnimationEnded = false;
        }
//        BroadcastMessage("OnTeleportCompleted", SendMessageOptions.DontRequireReceiver);
    }
}
