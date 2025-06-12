using System;
using UnityEngine;
using Cat;
using System.Collections;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    public VideoManager videoManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;
    
    private Rigidbody2D catRb;
    private Animator catAnim;
    
    public int jumpCount = 0;
    public float jumpPower = 30f;
    public float limitPower = 25f;
    
    void Awake()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        transform.localPosition = Vector3.zero;

        GetComponent<CircleCollider2D>().enabled = true;
        soundManager.audioSource.mute = false;
    }

    void Update()
    {
        Jump();
    }

    private void Jump()
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

                //Invoke("HappyVideo", 5f);

                StartCoroutine(EndingRoutine(true));
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

            //Invoke("SadVideo", 5f);

            StartCoroutine(EndingRoutine(false));
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
        }
    }

    IEnumerator EndingRoutine(bool isHappy)
    {
        yield return new WaitForSeconds(3.5f);

        videoManager.VideoPlayer(isHappy);

        yield return new WaitUntil(() => videoManager.vPlayer.isPlaying);

        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);

        soundManager.audioSource.mute = true;
    }

    //private void HappyVideo()
    //{
    //    videoManager.VideoPlayer(true);

    //    fadeUI.SetActive(false);
    //    gameOverUI.SetActive(false);

    //    soundManager.audioSource.mute = true;
    //}
    
    //private void SadVideo()
    //{
    //    videoManager.VideoPlayer(false);

    //    fadeUI.SetActive(false);
    //    gameOverUI.SetActive(false);

    //    soundManager.audioSource.mute = true;
    //}
    
}