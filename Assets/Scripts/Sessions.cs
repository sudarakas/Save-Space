using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sessions : MonoBehaviour {


    int playerScore = 0;

    private void Awake() {
        PlaySessionSetup();
        
    }

    private void PlaySessionSetup() {
        int gameSessions = FindObjectsOfType<Sessions>().Length;
        if (gameSessions > 1)
        {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int getScore() {
        return playerScore;
    }

    public void addToScore(int scoreVal) {
        playerScore += scoreVal;
    }

    public void resetGame() {
        Destroy(gameObject);
    }
}
