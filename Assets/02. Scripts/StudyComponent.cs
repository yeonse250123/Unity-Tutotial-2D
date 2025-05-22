using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    [SerializeField]
    private Mesh mesh;

    [SerializeField]
    private Material material;

    private int number1 = 1;
    private int number2 = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(AddMethod(number1, number2));
        CreateCube("Star");
    }

    private void CreateCube(string name = "Cube")
    {
        obj = new GameObject();
        obj.name = name;

        obj.AddComponent<MeshFilter>();
        obj.GetComponent<MeshFilter>().mesh = mesh;

        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshRenderer>().material = material;

        obj.AddComponent<BoxCollider>();
    }

    private int AddMethod(int a, int b)
    {
        int result = a + b;

        return result;
    }
}
