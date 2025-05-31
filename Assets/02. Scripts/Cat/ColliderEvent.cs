using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Enter");
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Collision Stay");
    }
    
    public void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Collision2D Exit");
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger2D Enter");
    }
    
    public void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Trigger2D Stay");
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger2D Exit");
    }
}