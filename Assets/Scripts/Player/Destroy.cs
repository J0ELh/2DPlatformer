using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI lives;
    public static int lives_counter = 3;
    void OnDestroy() {
        lives_counter--;

        if (lives_counter <= 0) {
            SceneManager.LoadScene(2);
            lives_counter = 3;
        } else {
            SceneManager.LoadScene(1);
        }
    }

    void Update() {
        lives.SetText((lives_counter).ToString());
    }
}
