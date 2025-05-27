using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private Vector3 returnPos;

    private void Start()
    {
        returnPos = new Vector3(30f, transform.position.y, 0f);
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;

        Debug.Log(Time.fixedDeltaTime);

        if (transform.position.x <= -30f)
        {
            transform.position = returnPos;
        }
    }
}
