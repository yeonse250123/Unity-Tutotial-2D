using UnityEngine;

public class RouletteController : MonoBehaviour
{
    [SerializeField] private float rotSpeed;

    [SerializeField] private bool isStop;

    private void Start()
    {
        rotSpeed = 0f;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 200f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true;
        }

        if (isStop == true)
        {
            rotSpeed *= 0.98f;

            if (rotSpeed < 0.01f)
            {
                rotSpeed = 0f;
                isStop = false;
            }
        }
    }
}
