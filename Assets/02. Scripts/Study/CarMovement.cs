using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D carRb;

    private float h;

    void Update()
    {
        h = Input.GetAxis("Horizontal");

        // Transform 이동
        // transform.position += Vector3.right * h * moveSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        // Rigidbody 이동
        carRb.linearVelocityX = h * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"OnCollisionEnter2D");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log($"OnCollisionStay2D");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log($"OnCollisionExit2D");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"OnTriggerEnter2D");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log($"OnTriggerStay2D");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"OnTriggerExit2D");
    }
}