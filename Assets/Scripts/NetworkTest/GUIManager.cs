#region Constructor
using UnityEngine;
using System.Collections;
#endregion

public class GUIManager : MonoBehaviour 
{
	#region Private Variables
	private string	connectionIP;
	private int		connectionPort;

	private bool	isSecondPlayerReady;
	#endregion

	#region Public Variables
	public Texture2D connectButtonTexture;
	public Texture2D startButtonTexture;
	#endregion

	#region Constructor
	void Start () 
	{
		connectionIP = "192.168.16.74";
		connectionPort = 25001;

		isSecondPlayerReady = false;
	}
	#endregion
	
	#region Loop
	void Update () 
	{
	
	}

	void OnGUI() 
	{
		Debug.Log("In GUI");

		if(Network.peerType == NetworkPeerType.Disconnected)
		{
			if(GUI.Button(new Rect(10.0f, 10.0f, 100.0f, 100.0f), connectButtonTexture))
			{
				Network.Connect(connectionIP, connectionPort);
			}

			if(GUI.Button(new Rect(150.0f, 10.0f, 100.0f, 100.0f), startButtonTexture))
			{
				Network.InitializeServer(10, connectionPort, false);
			}
		}
		else if(Network.peerType == NetworkPeerType.Server)
		{
			if(Network.connections.Length == 0)
			{
				GUI.Label(new Rect(200, 200, 150, 30), "Waiting For Player 2...");
			}
			else
			{
				if(isSecondPlayerReady == false)
				{
					GUI.Label(new Rect(200, 200, 150, 30), "Player 2 connecting ...");
				}
				else
				{
					GUI.Label(new Rect(200, 200, 150, 30), "GO NINJAS!!");
				}
			}
		}
		else if(Network.peerType == NetworkPeerType.Client)
		{
			networkView.RPC("ClientConnect", RPCMode.Server);
			GUI.Label(new Rect(200, 200, 150, 30), "GO NINJAS!!");
		}
	}
	#endregion

	#region Methods
	[RPC]
	public void ClientConnect()
	{
		isSecondPlayerReady = true;
	}
	#endregion
}
