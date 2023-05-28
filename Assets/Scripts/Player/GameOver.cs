using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Destroy destroy;

    public void gameOver() {
        SceneManager.LoadScene(2);
    }

    public void respawn() {
        destroy.respawn();
    }
}
