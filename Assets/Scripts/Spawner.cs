using UnityEngine;


public class Spawner : MonoBehaviour
{

    public int level;
    public Transform[] spawnPoints;
    public SpawnData[] spawnData;
    float timer = 0f;

    void Awake()
    {
        // ... 자식 오브젝트들의 Transform 컴포넌트를 가져옴
        spawnPoints = GetComponentsInChildren<Transform>();
        Debug.Log("spawnPoints.Length: " + spawnPoints.Length);
    }

    void Update()
    {

        timer += Time.deltaTime;
        // ... 게임 시간을 10초로 나눈 값을 정수로 변환하여 레벨 설정
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1);

       
        if (timer > spawnData[level].spawnTime)
        {
            //Debug.Log("level: " + level + " timer: " + timer + " spawnTime: " + spawnData[level].spawnTime);
            timer = 0;
           // Spawn();

            Debug.Log("Spawn 후 timer: " + timer); 
        }


    }

    void Spawn()
    {
        // ... 풀에서 랜덤한 적 오브젝트를 가져옴
        //GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, GameManager.instance.pool.prefabs.Length));
        GameObject enemy = GameManager.instance.pool.Get(0);
        // ... 랜덤한 스폰 위치를 선택하여 적 오브젝트를 위치시킴
        enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]); 
    }
}

[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;


}