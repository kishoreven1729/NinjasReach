using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	#region Public Variables
	public Transform serverCharacter;
	public Transform clientCharacter;
	#endregion

	public static InputManager instance;


	void Awake() {
		instance = this;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			if(Network.isClient)
			{
				if(PlayerSpawnPoint.instance.clientCharacter != null)
				{
					PlayerSpawnPoint.instance.clientCharacter.SendMessage("CheckInput", SendMessageOptions.DontRequireReceiver);
				}
			}
			else if(Network.isServer)
			{
				if(PlayerSpawnPoint.instance.serverCharacter != null)
				{
					PlayerSpawnPoint.instance.serverCharacter.SendMessage("CheckInput", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
