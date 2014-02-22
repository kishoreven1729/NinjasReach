using UnityEngine;
using System.Collections;

public class PlayerSpawnPoint : MonoBehaviour {

    public GameObject playerPrefab;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        GameObject go = Instantiate(playerPrefab, transform.position, Quaternion.identity) as GameObject;
        Camera.main.SendMessage("SetTarget", go.transform);
    }
}
