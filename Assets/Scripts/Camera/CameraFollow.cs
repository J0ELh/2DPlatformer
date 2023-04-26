using UnityEngine;

/**
 * @author Joel Hempel
 * inspired by https://generalistprogrammer.com/unity/unity-2d-how-to-make-camera-follow-player/#:~:text=You%20can%20use%20a%20c%23%20script,and%201st%20person%20camera%20follows.
 * NEED TO FIX THE SMOOTHING. DOESN'T SEEM TO BE WORKING PROPERLY
 * */
public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    void Update()
    {
        Vector3 targetPostition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPostition, ref velocity, smoothTime);
    }


}