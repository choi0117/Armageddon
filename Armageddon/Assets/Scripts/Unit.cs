using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// 유닛이 몬스터를 공격하는 스크립트
public class Unit : MonoBehaviour
{
    // 유닛의 공격 범위
    public float attackRange = 1.5f;
    // 공격 속도
    public float attackInterval = 1.0f;
    // 공격 데미지
    public int damage = 5;
    // 공격 타이머
    private float attackTimer = 0f;

    private Monster currentTarget;

    void Update()
    {
        // 공격 타이머를 증가시킴
        attackTimer += Time.deltaTime;

        if (currentTarget == null)
        {
            // 몬스터를 찾음
            FindNearestTarget();
        }
        else
        {
            // 몬스터와의 거리 계산
            float distance = Vector2.Distance(transform.position, currentTarget.transform.position);

            if (distance > attackRange)
            {
                currentTarget = null;
                return;
            }

            if (attackTimer >= attackInterval)
            {
                currentTarget.TakeDamage(damage);
                attackTimer = 0f;
            }
        }
    }

    void FindNearestTarget()
    {
        // 몬스터를 찾기 위해 오버랩 서클을 사용
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);
        // 가장 가까운 몬스터를 찾음
        float closestDistance = float.MaxValue;
        //  몬스터를 저장할 변수
        Monster nearest = null;

        foreach (var hit in hits)
        {
            // 몬스터인지 확인
            if (hit.CompareTag("Monster"))
            {
                // 몬스터와의 거리 계산
                float dist = Vector2.Distance(transform.position, hit.transform.position);
                if (dist < closestDistance)
                {
                    // 가장 가까운 몬스터를 업데이트
                    closestDistance = dist;
                    nearest = hit.GetComponent<Monster>();
                }
            }
        }
        // 몬스터가 없으면 null로 설정
        currentTarget = nearest;
    }
}
