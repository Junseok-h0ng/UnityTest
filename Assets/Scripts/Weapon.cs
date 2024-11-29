using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;
        }
        // 테스트 코드
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("LevelUp 호출");
            LevelUp(20, 10);
        }

    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count = count;

        if (id == 0)
            Batch();

    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = -150;
                Batch();
                Debug.Log("Batch 후");
                break;
            default:
                break;
        }

    }

    void Batch()
    {
        for (int index = 0; index < count; index++)
        {

            Transform bullet;

            // 자식이 있으면 자식을 사용
            if (index < transform.childCount)
            {
                bullet = transform.GetChild(index);
            }
            else
            {
                // 자식이 없으면 새로 생성
                bullet = GameManager.instance.pool.Get(1).transform;
                bullet.parent = transform;
            }
            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);

            // 위쪽 방향으로 1.5 위치시킴
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1); // -1은 무한발사


        }
    }
}
