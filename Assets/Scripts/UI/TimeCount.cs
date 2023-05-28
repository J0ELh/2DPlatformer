using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeCount : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI time_text;
    [SerializeField] private float start_time;

    // Start is called before the first frame update
    void Start()
    {
        time_text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        time_text.text = ((int)start_time).ToString();
        start_time -= Time.deltaTime;
        if (System.Int32.Parse(time_text.text) <= 0) {
            SceneManager.LoadScene(2);
        }
    }
}
