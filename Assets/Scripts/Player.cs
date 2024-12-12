using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    [SerializeField]
    public float speed = 100f;
    public Hand[] hands;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator animator;
    public Scanner scanner;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>(true);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        // 현재 위치에서 입력 벡터만큼 이동
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate()
    {

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }

        animator.SetFloat("Speed", inputVec.magnitude);
    }
}
