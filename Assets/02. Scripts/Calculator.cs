using UnityEngine;

public class Calculator : MonoBehaviour
{
    public int a;
    public int number1, number2; // 멤버 변수 (필드)

    void Start()
    {
        int addResult = AddMethod(a); // 함수 호출

        int minusResult = MinusMethod(a); // 함수 호출

        Debug.Log($"더한 값 : {addResult} / 뺀 값 : {minusResult}");
    }

    int AddMethod(int a)
    {
        // 지역 변수 result
        int result = number1 + number2 + a;

        return result;
    }

    int MinusMethod(int a)
    {
        // 지역 변수 result
        int result = number1 - number2 - a;

        return result;
    }
}