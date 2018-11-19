using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [SerializeField]
    float waitTime = 1.5f;

    public void LoadStartMenu() {
        SceneManager.LoadScene(0);
    }

    public void LoadGame() {
        SceneManager.LoadScene("Game");
        FindObjectOfType<Sessions>().resetGame();
    }

    public void LoadGameOver() {
        StartCoroutine(WaitLoad());
    }
    IEnumerator WaitLoad() {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Game Over"); 

    }

    public void QuitGame() {
        Application.Quit();
    }
}
