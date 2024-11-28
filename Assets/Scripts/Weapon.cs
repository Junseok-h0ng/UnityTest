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
        switch(id)
                {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    public void Init()
    {
        switch(id)
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
        for(int index = 0; index < count; index++)
        {
            
            Transform bullet = GameManager.instance.pool.Get(1).transform;
            // 부모를 자기자신으로 설정
            bullet.parent = transform;
            // bullet의 로컬 위치를 초기화
            bullet.localPosition = Vector3.zero;
            bullet.GetComponent<Bullet>().Init(damage, -1); // -1은 무한발사
        }
    }
}
