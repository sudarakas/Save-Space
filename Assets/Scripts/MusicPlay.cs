using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour {

	
	void Awake () {
        PlayMusicSingle(); 
	}

    private void PlayMusicSingle() {
        if (FindObjectsOfType(GetType()).Length > 1)
        {

            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
