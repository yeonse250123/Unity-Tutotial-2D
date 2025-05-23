using UnityEngine;

public class StudyLookAt : MonoBehaviour
{
    [SerializeField] private Transform targetTf;
    [SerializeField] private Transform turretHead;

    void Start() // 1�� ���� -> �����ΰ��� �����ϴ� ���
    {
        targetTf = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() // �����ΰ��� �ٶ󺸴� ���
    {
        turretHead.LookAt(targetTf);
    }
}