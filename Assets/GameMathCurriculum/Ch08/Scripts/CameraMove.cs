using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0, 2, -5);

    public float smooth = 0.2f;
    public float rotatesmooth = 10f;

    private Vector3 velocity = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dircetion = target.position - target.TransformDirection(offset);
        transform.position = Vector3.SmoothDamp(transform.position, dircetion,
           ref velocity, smooth);

        transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, rotatesmooth * Time.deltaTime);
    }
}
