using UnityEngine;

public class WhileLoop : MonoBehaviour
{
    public int i = 0;

    void Start()
    {
        while (i < 10)
        {
            i++;
            Debug.Log($"현재 {i}입니다.");
        }
    }
}
