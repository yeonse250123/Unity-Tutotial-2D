using System;
using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;

    private Rigidbody2D catRb;
    private Animator catAnim;

    public float jumpPower = 10f;
    //public float limitPower = 9f;

    public bool isGround = false;
    
    public int jumpCount = 0;

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            catAnim.SetTrigger("Jump");

            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++; // 1씩 증가

            soundManager.OnJumpSound();
        }

        //if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 5)
        //{
        //    catAnim.SetTrigger("Jump");
        //    catAnim.SetBool("isGround", false);
        //    jumpCount++; // 1씩 증가
        //    soundManager.OnJumpSound();
        //    catRb.AddForceY(jumpPower, ForceMode2D.Impulse);

        //    if (catRb.linearVelocityY > limitPower) // 자연스러운 점프를 위한 속도 제한
        //        catRb.linearVelocityY = limitPower;
        //}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", false);
            isGround = false;
        }
    }
}