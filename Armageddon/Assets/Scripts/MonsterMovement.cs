using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스트 이동을 관리하는 스크립트
public class MonsterMovement : MonoBehaviour
{
    // 웨이포인트 리스트
    public List<Transform> waypoints;
    // 몬스터 이동 속도
    public float speed = 0.6f;
    // 현재 웨이포인트 인덱스
    private int currentWaypointIndex = 0;

    // 애니메이션과 스프라이트 렌더러
    private Animator animator;
    // 스프라이트 렌더러
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // 웨이포인트가 없으면 종료    
        animator = GetComponent<Animator>();
        // 스프라이트 렌더러가 없으면 종료
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 몬스터 이동
        if (waypoints.Count == 0 || currentWaypointIndex >= waypoints.Count) return;

        // 현재 웨이포인트 위치
        Transform target = waypoints[currentWaypointIndex];
        // 몬스터가 웨이포인트로 이동
        Vector3 direction = target.position - transform.position;
        // 이동 방향 벡터를 정규화
        transform.position += direction.normalized * speed * Time.deltaTime;

        // 애니메이션 파라미터 설정
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);

        // 오른쪽으로 이동 중이면 좌우 반전 ON
        if (direction.x < 0.1f)
        {
            spriteRenderer.flipX = true;
        }
        // 왼쪽으로 이동 중이면 좌우 반전 OFF
        else if (direction.x > -0.1f)
        {
            spriteRenderer.flipX = false;
        }

        // 웨이포인트 도착 시 다음으로
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            // 웨이포인트에 도착했을 때 애니메이션 파라미터 설정
            currentWaypointIndex++;
        }
    }
}
