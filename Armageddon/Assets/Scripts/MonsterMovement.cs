using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스트 이동을 관리하는 스크립트
public class MonsterMovement : MonoBehaviour
{
    // 몬스터가 이동할 경로를 정의하는 웨이포인트 리스트
    public List<Transform> waypoints;
    // 몬스터의 이동 속도
    public float speed = 0.6f;
    // 현재 웨이포인트 인덱스
    private int currentWaypointIndex = 0;

    void Update()
    {
        // 매 프레임마다 몬스터의 위치를 업데이트
        if (waypoints.Count == 0 || currentWaypointIndex >= waypoints.Count) return;

        // 웨이포인트에 도달했는지 확인
        Transform target = waypoints[currentWaypointIndex];
        Vector3 direction = target.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

        // 웨이포인트에 도달했으면 다음 웨이포인트로 이동
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            // 웨이포인트에 도달했으므로 인덱스를 증가시킴
            currentWaypointIndex++;

            // 모든 웨이포인트를 다 돌았으면 몬스터를 파괴
            if (currentWaypointIndex >= waypoints.Count)
            {
                // 몬스터를 파괴
                Destroy(gameObject);
            }
        }
    }
}
