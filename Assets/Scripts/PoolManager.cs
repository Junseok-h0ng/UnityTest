using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    // .. 프리팹들을 보관할 변수
    public GameObject[] prefabs;
    // .. 풀들을 보관할 리스트
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        // ... 선택된 풀에 비활성화된 게임오브젝트가 있으면 반환
        foreach (GameObject item in pools[index])
        {
            // ... 비활성화된 게임오브젝트가 있으면 반환
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        // ... 선택된 풀에 비활성화된 게임오브젝트가 없으면 새로 생성
        if (select == null)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        // ... 선택된 풀에 비활성화된 게임오브젝트가 없으면 새로 생성
        return select;
    }
}
