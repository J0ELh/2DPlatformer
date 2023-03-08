using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @author Joel Hempel
 * inspired by https://generalistprogrammer.com/unity/unity-2d-how-to-make-camera-follow-player/#:~:text=You%20can%20use%20a%20c%23%20script,and%201st%20person%20camera%20follows.
 * NEED TO FIX THE SMOOTHING. DOESN'T SEEM TO BE WORKING PROPERLY
 * */
public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;
    private Vector3 smoothPos;
    public float smoothSpeed = 0.5f; //rate at which we're smoothing camera movement


    // Update is called once per frame
    void LateUpdate()
    {
        //this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
        smoothPos = Vector3.Lerp(this.transform.position, new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z), smoothSpeed);
        this.transform.position = smoothPos;
        //Lerp is supposed to smooth the camera
        //updated position = change the vectors to this new vector(match the followed object x, match the followed object x, keep z because 2D game)

    }
}