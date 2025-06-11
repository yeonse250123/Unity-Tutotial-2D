using System;
using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;

    public GameObject happyVideo;
    public GameObject sadVideo;
    
    private Rigidbody2D catRb;
    private Animator catAnim;
    
    public int jumpCount = 0;
    public float jumpPower = 30f;
    public float limitPower = 25f;
    
    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 10)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("isGround", false);
            jumpCount++;
            soundManager.OnJumpSound();
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);

            if (catRb.linearVelocityY > limitPower) // 자연스러운 점프를 위한 속도 제한
                catRb.linearVelocityY = limitPower;
        }

        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocityY * 2.5f;
        transform.eulerAngles = catRotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            other.gameObject.SetActive(false);
            other.transform.parent.GetComponent<ItemEvent>().particle.SetActive(true);
            
            GameManager.score++;
            
            if (GameManager.score == 10) // 사과를 10개 먹어서 성공
            {
                fadeUI.SetActive(true);
                fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.white);
                this.GetComponent<CircleCollider2D>().enabled = false;

                Invoke("HappyVideo", 5f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipe")) // 파이프에 부딪혀서 실패
        {
            soundManager.OnColliderSound();

            gameOverUI.SetActive(true); // 게임 오버 켜기
            fadeUI.SetActive(true); // 페이드 켜기
            fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.black); // 페이드 실행
            this.GetComponent<CircleCollider2D>().enabled = false;
            
            Invoke("SadVideo", 5f);
        }
        
        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
        }
    }

    private void HappyVideo()
    {
        happyVideo.SetActive(true);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);

        soundManager.audioSource.mute = true;
    }
    
    private void SadVideo()
    {
        sadVideo.SetActive(true);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);

        soundManager.audioSource.mute = true;
    }
    
}