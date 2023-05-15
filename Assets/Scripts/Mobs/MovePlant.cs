using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlant : MonoBehaviour
{
    private bool goingDown = false;
    private bool doneRandomWait = true;
    private float randomWaitTime;
    // private Transform t;
    // Start is called before the first frame update
    private Vector3 targetHeight;
    private Vector3 baseHeight;
    private float speed = 1f;

    void Start()
    {
        baseHeight = transform.position;
        targetHeight = transform.position + new Vector3(0f, 1.2f, 0f);


        // Debug.Log(baseHeight);
        // Debug.Log(targetHeight);
        // Debug.Log(Time.deltaTime * 60);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(transform.position);
        if (transform.position.y > targetHeight.y && !goingDown) {
            speed = -speed;
            goingDown = true;
            doneRandomWait = false;
            randomWaitTime =  (900000f  + Random.Range(0f, 20* 90000f)) * Time.deltaTime; //assuming probably refresh rate around 60hz
            // Debug.Log("greater");
        }
        else if (transform.position.y < baseHeight.y && goingDown) {
            doneRandomWait = false;
            randomWaitTime =  (900000f  + Random.Range(0f, 20* 90000f)) * Time.deltaTime; //assuming probably refresh rate around 60hz
            // Debug.Log("Counter is set to " + randomWaitTime);
            speed = -speed;
            goingDown = false;
            // Debug.Log("smaller");
            
        }
        //move if not waiting. If waiting, decrease timer and indicate once finished
        if (doneRandomWait) {
           transform.position = Time.deltaTime * (new Vector3(0f, speed, 0f) ) + transform.position; 
        } else {
            if (randomWaitTime < 0) {
                doneRandomWait = true;
                // Debug.Log("done");
            } else {
                randomWaitTime -= 1;
            }
            Debug.Log(randomWaitTime);
            
        }
        // Debug.Log(speed);
    }
}
