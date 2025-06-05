using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    private void Update()
    {
        //MouseClickEvent();
    }

    private void MouseClickEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("GetMouseButtonDown");
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("GetMouseButton");
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("GetMouseButtonUp");
        }
    }
}