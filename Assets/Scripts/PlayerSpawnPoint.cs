using UnityEngine;
using System.Collections;

public class PlayerSpawnPoint : MonoBehaviour {

    public GameObject playerPrefab;
	public static PlayerSpawnPoint instance;

	void Awake()
	{
		instance = this;
	}

    void Start()
    {
        //Spawn();
    }

    void Spawn()
    {
        GameObject go = Instantiate(playerPrefab, transform.position, Quaternion.identity) as GameObject;
        Camera.main.SendMessage("SetTarget", go.transform);
    }

	public void NetworkSpawn()
	{
		if(Network.isServer)
		{
			Vector3 position = transform.position;
			position.x -= 50.0f;

			GameObject go = Network.Instantiate(playerPrefab, transform.position, Quaternion.identity, 0) as GameObject;
			Camera.main.SendMessage("SetTarget", go.transform);
		}
		else if(Network.isClient)
		{
			GameObject go = Network.Instantiate(playerPrefab, transform.position, Quaternion.identity, 0) as GameObject;
			Camera.main.SendMessage("SetTarget", go.transform);
		}
	}
}
