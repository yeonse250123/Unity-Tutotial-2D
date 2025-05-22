using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    [SerializeField] private float destroyTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    private void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}°¡ ÆÄ±«µÆ½À´Ï´Ù.");
    }
}