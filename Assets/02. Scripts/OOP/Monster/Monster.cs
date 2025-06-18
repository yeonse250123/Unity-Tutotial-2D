using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public abstract class Monster : MonoBehaviour
{
    private SpawnManager spawnManager;

    private SpriteRenderer sRenderer;
    private Animator animator;

    [SerializeField] protected float hp = 3f;
    [SerializeField] protected float moveSpeed = 3f;

    private int dir = 1;
    private bool isMove = true;
    private bool isHit = false;

    public abstract void Init();

    void Start()
    {
        spawnManager = FindFirstObjectByType<SpawnManager>();

        sRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        Init();
    }

    void OnMouseDown()
    {
        StartCoroutine(Hit(1));
    }

    void Update()
    {
        Move();
    }

    /// <summary>
    /// 몬스터가 좌우로 이동하는 기능
    /// </summary>
    void Move()
    {
        if (!isMove)
            return;

        transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;

        if (transform.position.x > 8f)
        {
            dir = -1;
            sRenderer.flipX = true;
        }
        else if (transform.position.x < -8f)
        {
            dir = 1;
            sRenderer.flipX = false;
        }
    }

    /// <summary>
    /// 몬스터 피격 및 데스 기능
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    private IEnumerator Hit(float damage)
    {
        if (isHit)
            yield break;

        isHit = true;
        isMove = false;

        hp -= damage;

        if (hp <= 0) // 몬스터 죽음
        {
            animator.SetTrigger("Death");

            spawnManager.DropCoin(transform.position);

            yield return new WaitForSeconds(3f);
            Destroy(gameObject);

            yield break;
        }

        animator.SetTrigger("Hit");

        yield return new WaitForSeconds(0.6f);
        isHit = false;
        isMove = true;
    }
    
}