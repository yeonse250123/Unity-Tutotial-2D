using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = this.transform.position + Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = this.transform.position + Vector3.forward * moveSpeed * Time.deltaTime;

        //transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}