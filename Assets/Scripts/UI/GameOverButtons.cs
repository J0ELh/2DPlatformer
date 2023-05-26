using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void OnRestart() {
        SceneManager.LoadScene(0);
    }

    public void OnQuit() {
        Application.Quit();
    }
}
