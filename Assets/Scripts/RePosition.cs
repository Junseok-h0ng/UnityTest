using UnityEngine;

public class RePosition : MonoBehaviour
{
    // 플레이어가 Area를 벗어날 때 호출되는 함수
    void Start()
    {
        Debug.Log("Start called");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log($"OnTriggerEnter2D called with: {other.gameObject.name}, Tag: {other.tag}");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Area 태그가 아닌 경우 무시
        if (!other.CompareTag("Area"))
            return;

        // 플레이어와 현재 오브젝트의 위치 가져오기
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        Debug.Log($"playerPos: {playerPos}, myPos: {myPos}");
        // X축과 Y축의 거리 차이 계산
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);
        Debug.Log($"diffX: {diffX}, diffY: {diffY}");

        // 플레이어의 이동 방향 가져오기
        Vector3 playerDir = GameManager.instance.player.inputVec;
        // 이동 방향에 따라 -1 또는 1 설정
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":

                // X축 차이가 더 큰 경우 좌우로 재배치
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                // Y축 차이가 더 큰 경우 상하로 재배치
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemey":
                break;


        }
    }
}
