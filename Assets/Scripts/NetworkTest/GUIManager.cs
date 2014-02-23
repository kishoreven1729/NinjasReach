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
//		connectionIP = "192.168.16.74";
		connectionIP = Network.player.externalIP;
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
		if(Network.peerType == NetworkPeerType.Disconnected)
		{
			if(GUI.Button(new Rect(10.0f, 10.0f, 200.0f, 65.0f), connectButtonTexture))
			{
				Network.Connect(connectionIP, connectionPort);
			}

			if(GUI.Button(new Rect(250.0f, 10.0f, 200.0f, 65.0f), startButtonTexture))
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
				
				}
			}
		}
		else if(Network.peerType == NetworkPeerType.Client)
		{
			if(isSecondPlayerReady == false)
			{
				RequestServerConnect();
			}
			else
			{

			}
		}
	}
	#endregion

	#region Methods
	[RPC]
	public void RequestServerConnect()
	{
		networkView.RPC("ClientConnect", RPCMode.Server);
		isSecondPlayerReady = true;

		PlayerSpawnPoint.instance.NetworkSpawn();
	}

	[RPC]
	public void ClientConnect()
	{
		Debug.Log("Client Called");
		isSecondPlayerReady = true;

		PlayerSpawnPoint.instance.NetworkSpawn();
	}
	#endregion
}
