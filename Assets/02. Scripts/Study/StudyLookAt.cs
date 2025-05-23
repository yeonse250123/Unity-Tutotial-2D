using UnityEngine;

public class StudyLookAt : MonoBehaviour
{
    [SerializeField] private Transform targetTf;
    [SerializeField] private Transform turretHead;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePos;

    [SerializeField] private float timer;
    [SerializeField] private float cooldownTimer;

    void Start() // 1번 실행 -> 무엇인가를 셋팅하는 기능
    {
        targetTf = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() // 무엇인가를 바라보는 기능
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