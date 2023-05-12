using UnityEngine;

/**
 * @author Joel Hempel
 * inspired by https://generalistprogrammer.com/unity/unity-2d-how-to-make-camera-follow-player/#:~:text=You%20can%20use%20a%20c%23%20script,and%201st%20person%20camera%20follows.
 * */
public class CameraFollow : MonoBehaviour
{
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float edge_coord;


    void Start() {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 targetPostition = new Vector3(target.position.x, transform.position.y, -1f);
        transform.position = Vector3.SmoothDamp(transform.position, targetPostition, ref velocity, smoothTime);
        
        if (transform.position.x < 6.25) transform.position = new Vector3(6.25f, transform.position.y, transform.position.z);

    }


}