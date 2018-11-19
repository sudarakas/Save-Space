using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    Text playerSocre;
    Sessions gameSession;

	// Use this for initialization
	void Start () {
        playerSocre = GetComponent<Text>();
        gameSession = FindObjectOfType<Sessions>();
	}
	
	// Update is called once per frame
	void Update () {
        playerSocre.text = gameSession.getScore().ToString();

	}
}
