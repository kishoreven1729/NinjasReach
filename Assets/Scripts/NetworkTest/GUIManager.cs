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

	private bool	clientWins;
	private bool	serverWins;

	private Rect	logoDisplayRect;
	#endregion

	#region Public Variables
	public Texture2D connectButtonTexture;
	public Texture2D startButtonTexture;
	public Texture2D blackNinjaWins;
	public Texture2D whiteNinjaWins;
	public Texture2D logoTexture;

	public static GUIManager instance;
	#endregion

	#region Constructor
	void Awake()
	{
		instance = this;
	}


	void Start () 
	{
//		connectionIP = "192.168.16.74";
		connectionIP = "10.159.23.132";
		connectionPort = 25001;

		isSecondPlayerReady = false;

		clientWins = false;
		serverWins = false;

		logoDisplayRect = new Rect(Screen.width / 2 - logoTexture.width / 2, Screen.height / 2 - logoTexture.height / 2, logoTexture.width, logoTexture.height);
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

			GUI.Label(logoDisplayRect, logoTexture);
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
					Debug.Log(clientWins + ": " + serverWins);

					if(clientWins == true)
					{
						GUI.Label(logoDisplayRect, whiteNinjaWins);

						InputManager.instance.CanCheckInput = false;
					}
					else if(serverWins == true)
					{
						GUI.Label(logoDisplayRect, blackNinjaWins);

						InputManager.instance.CanCheckInput = false;
					}
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
				if(clientWins == true)
				{
					GUI.Label(logoDisplayRect, whiteNinjaWins);

					InputManager.instance.CanCheckInput = false;
				}
				else if(serverWins == true)
				{
					GUI.Label(logoDisplayRect, blackNinjaWins);

					InputManager.instance.CanCheckInput = false;
				}
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

	[RPC]
	public void ClientWins()
	{
		Debug.Log("ClientWins: Client Wins Called");

		clientWins = true;

		networkView.RPC("TellServerClientWins", RPCMode.Server);
	}

	[RPC]
	public void ServerWins()
	{
		serverWins = true;

		networkView.RPC("TellClientServerWins", RPCMode.Others);
	}

	[RPC]
	public void TellClientServerWins()
	{
		serverWins = true;
	}

	[RPC]
	public void TellServerClientWins()
	{
		Debug.Log("TellServerClientWins: Client Wins Called");

		clientWins = true;
	}
	#endregion
}
