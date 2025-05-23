using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField] private Transform targetPlanet;

    [SerializeField] private float rotSpeed = 30f; // ���� �ӵ�

    [SerializeField] private float revolutionSpeed = 100f; // ���� �ӵ�

    [SerializeField] private bool isRevolution = false; // �� Ÿ�� -> true / false

    void Update()
    {
        // �ڱ� �ڽ��� ȸ���ϴ� ���
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);

        if (isRevolution == true)
        {
            // �����ϴ� ���
            transform.RotateAround(targetPlanet.position, Vector3.up, revolutionSpeed * Time.deltaTime);
        }
    }
}