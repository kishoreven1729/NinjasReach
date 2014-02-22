using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public Rect rect;

//	public enum InGameState

	void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

	// Use this for initialization
	void Start () {
		rect = new Rect(0f, 0f, Screen.width, Screen.height);
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool OutOfBoundary(Vector3 pos)
	{
		if (rect.Contains(Camera.main.WorldToScreenPoint(pos)))
			return false;
		return true;
	}

	public void GameOver()
	{
		print("GameOver");
	}

}
