using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 dir;
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        dir = new Vector3(h, 0, v).normalized;
        //Debug.Log($"현재 입력 : {dir}");

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    private void Turn()
    {
        transform.LookAt(transform.position + dir);
    }
}
