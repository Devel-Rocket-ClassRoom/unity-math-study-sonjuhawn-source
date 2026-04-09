using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float rotateSpeed = 120f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Vertical");
        float rotateInput = Input.GetAxisRaw("Horizontal");

        transform.Rotate(Vector3.up * rotateInput * rotateSpeed * Time.deltaTime);

        Vector3 move = transform.forward * moveInput * moveSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }
}
