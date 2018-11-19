using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    Text playerHealth;
    Player player;

    // Use this for initialization
    void Start()
    {
        playerHealth = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.text = player.getHealth().ToString();

    }
}
