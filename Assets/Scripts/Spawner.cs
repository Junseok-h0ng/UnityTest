using UnityEngine;


public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    float timer;

    void Awake()
    {
        // ... 자식 오브젝트들의 Transform 컴포넌트를 가져옴
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer > 0.2f)
        {
            Spawn();
            timer = 0;
        }


    }

    void Spawn()
    {
        // ... 풀에서 랜덤한 적 오브젝트를 가져옴
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, GameManager.instance.pool.prefabs.Length));
        // ... 랜덤한 스폰 위치를 선택하여 적 오브젝트를 위치시킴
        enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;

    }
}
