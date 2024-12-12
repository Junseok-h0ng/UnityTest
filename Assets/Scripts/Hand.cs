using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool isLeft;
    public SpriteRenderer sprite;

    SpriteRenderer player;

    Vector3 rightpos = new Vector3(0.06f,-0.04f,0f);
    Vector3 rightPosReverse = new Vector3(-0.03f, -0.04f, 0);
    Vector3 leftpos = new Vector3(-0.039f,-0.05f,0);
    Vector3 leftPosReverse = new Vector3(0.049f , -0.04f , 0);
    Quaternion leftRot = Quaternion.Euler(0,0,-35f);
    Quaternion leftRotReverse = Quaternion.Euler(0,0,-135f);

    void Awake()
    {
        player = GetComponentsInParent<SpriteRenderer>()[1];
    }

    void LateUpdate()
    {
        bool isReverse = player.flipX;

        if(isLeft) // 근접
        {
            transform.localPosition = isReverse ? leftPosReverse : leftpos;
            transform.localRotation = isReverse ? leftRotReverse : leftRot;
            sprite.flipY = isReverse;
        }
        else    // 원거리
        {
            transform.localPosition = isReverse ? rightPosReverse : rightpos;
            sprite.flipX = isReverse;
            sprite.sortingOrder = isReverse ? 4 : 6;
        }
    }
}

