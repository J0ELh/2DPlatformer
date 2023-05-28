using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI lives;
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask death;
    public static int lives_counter = 3;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip dead_sound;

    void OnCollisionEnter2D(Collision2D col) {
        if (((1 << col.gameObject.layer) & death) != 0)
            OnDeath();
    }

    public void OnDeath() {
        source.Stop();
        source.PlayOneShot(dead_sound);
        anim.SetBool("dead", true);
        Destroy(gameObject.GetComponent<Rigidbody2D>());
    }

    public void respawn() {
        lives_counter--;

        if (lives_counter <= 0) {
            SceneManager.LoadScene(2);
            lives_counter = 3;
        } else {
            SceneManager.LoadScene(1);
        }
    }

    void Start() {
        source = GetComponent<AudioSource>();
    }

    void Update() {
        lives.SetText((lives_counter).ToString());
    }
}
