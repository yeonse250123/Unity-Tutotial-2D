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
        obj.name = "어몽어스 캐릭터";

        Transform objTf = obj.transform;
        int count = objTf.childCount;

        Debug.Log($"캐릭터의 자식 오브젝트 수 : {count}");

        Debug.Log($"캐릭터의 첫번째 자식 오브젝트의 이름 : {objTf.GetChild(0).name}");

        Debug.Log($"캐릭터의 마지막 자식 오브젝트의 이름 : {objTf.GetChild(objTf.childCount -1).name}");
    }
}
