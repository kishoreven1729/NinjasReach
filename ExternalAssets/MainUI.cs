using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {
	public Texture startTexture;
	public Texture joinTexture;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (100, 270, 100, 35), startTexture)) 
		{
			Debug.Log("start");
		}
			

		if (GUI.Button (new Rect (100, 310, 100, 35), joinTexture)) 
		{
			Debug.Log("join");
		}
			
	}
}
