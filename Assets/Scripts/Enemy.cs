using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    Rigidbody2D target;
    bool isLive;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator anim;

    WaitForFixedUpdate wait;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        wait = new WaitForFixedUpdate();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.linearVelocity = Vector2.zero;
    }

    void LateUpdate()
    {
        sprite.flipX = target.position.x < rigid.position.x;
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
    }
    // .. 초기화 함수
    public void Init(SpawnData data)
    {
        // .. 애니메이션 설정
        anim.runtimeAnimatorController = animCon[data.spriteType];
        // .. 속도 설정
        speed = data.speed;
        // .. 체력 설정
        health = data.health;
        // .. 최대 체력 설정
        maxHealth = data.health;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bullet"))
            return;

        health -= other.GetComponent<Bullet>().damage;

        StartCoroutine(KnockBack());

        if (health > 0)
        {
            //..Live, Hit Action
            anim.SetTrigger("Hit");
        }
        else
        {
            //Die
            Dead();
        }
    }

    IEnumerator KnockBack()
    {
        yield return wait;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}
