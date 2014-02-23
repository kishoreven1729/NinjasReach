﻿using UnityEngine;
using System.Collections;

public class Ruler : MonoBehaviour {

	public float actualHeight;
	public float rulerHeight;
	private GameObject player1;
	public GameObject player2;
	public GameObject p1Lable;
	public GameObject p2Lable;
	public GameObject waterLable;
	public GameObject waterHeight;

	private float ratio; 
	// Use this for initialization
	void Start () {
		ratio = rulerHeight / actualHeight;

	}
	
	// Update is called once per frame
	void Update () {

        if (player1 == null)
        {
            player1 = GameManager.Instance.player1.gameObject;
            if (player1 == null)
                return;
        }


//        player1

		//p1Lable.transform.localPosition= new Vector3(0,200/100,0);// new Vector3 (0,player1.transform.position.y * ratio,0);
		//float y = (float)player1.transform.position.y;
		p1Lable.transform.localPosition= new Vector3(-0.1f,(float)player1.transform.position.y * ratio,1f);
//		p2Lable.transform.localPosition= new Vector3(0.2f,(float)player2.transform.position.y * ratio,1);
		//p2Lable.transform.position.y = new Vector3(0,35f,0);//new Vector3 (0,player1.transform.position.y * ratio,0);

		waterLable.transform.localScale = new Vector3 (1, waterHeight.transform.position.y *100/ actualHeight, 1);
	}
}
