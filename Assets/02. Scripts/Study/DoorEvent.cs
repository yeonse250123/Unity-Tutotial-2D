using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    private Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Animator.SetTrigger("Open");
    }
}
