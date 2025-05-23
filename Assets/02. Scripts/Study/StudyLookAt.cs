using UnityEngine;

public class StudyLookAt : MonoBehaviour
{
    [SerializeField] private Transform targetTf;
    [SerializeField] private Transform turretHead;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePos;

    [SerializeField] private float timer;
    [SerializeField] private float cooldownTimer;

    void Start() // 1�� ���� -> �����ΰ��� �����ϴ� ���
    {
        targetTf = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() // �����ΰ��� �ٶ󺸴� ���
    {
        turretHead.LookAt(targetTf);

        timer += Time.deltaTime;
        if (timer >= cooldownTimer)
        {
            timer = 0f;
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}