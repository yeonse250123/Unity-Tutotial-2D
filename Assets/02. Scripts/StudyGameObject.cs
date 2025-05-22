using UnityEngine;

public class StudyGameObject : MonoBehaviour
{
    [SerializeField] private GameObject amongus;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateAmonus();
    }

    private void CreateAmonus()
    {
        GameObject obj = Instantiate(amongus);
        obj.name = "���� ĳ����";

        Transform objTf = obj.transform;
        int count = objTf.childCount;

        Debug.Log($"ĳ������ �ڽ� ������Ʈ �� : {count}");

        Debug.Log($"ĳ������ ù��° �ڽ� ������Ʈ�� �̸� : {objTf.GetChild(0).name}");

        Debug.Log($"ĳ������ ������ �ڽ� ������Ʈ�� �̸� : {objTf.GetChild(objTf.childCount -1).name}");
    }
}
