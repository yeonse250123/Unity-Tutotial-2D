using UnityEngine;

public class Calculator : MonoBehaviour
{
    public int a;
    public int number1, number2; // ��� ���� (�ʵ�)

    void Start()
    {
        int addResult = AddMethod(a); // �Լ� ȣ��

        int minusResult = MinusMethod(a); // �Լ� ȣ��

        Debug.Log($"���� �� : {addResult} / �� �� : {minusResult}");
    }

    int AddMethod(int a)
    {
        // ���� ���� result
        int result = number1 + number2 + a;

        return result;
    }

    int MinusMethod(int a)
    {
        // ���� ���� result
        int result = number1 - number2 - a;

        return result;
    }
}