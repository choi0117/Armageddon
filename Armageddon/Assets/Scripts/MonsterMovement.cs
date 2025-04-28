using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스트 이동을 관리하는 스크립트
public class MonsterMovement : MonoBehaviour
{
    // 이동할 웨이포인트 리스트
    public List<Transform> waypoints;
    // 이동 속도
    public float speed = 0.6f;
    // 현재 웨이포인트 인덱스
    private int currentWaypointIndex = 0;

    // 애니메이션 관련
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // 공격 관련 변수
    public float attackRange = 0.5f;
    // 공격 쿨타임 및 데미지
    public float attackCooldown = 1.5f;
    // 공격 데미지
    public int attackDamage = 10;
    // 공격 쿨타임 타이머
    private float attackTimer = 0f;

    private GameObject targetUnit;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        attackTimer += Time.deltaTime;

        // 근처 유닛 탐지
        if (DetectUnit())
        {
            // 유닛 공격
            if (attackTimer >= attackCooldown)
            {
                Attack();
                attackTimer = 0f;
            }

            // 공격 중이므로 이동하지 않음
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
            return;
        }

        // 유닛이 없을 때만 이동
        Move();
    }

    void Move()
    {
        //// 웨이포인트가 없거나 인덱스가 범위를 초과하면 이동하지 않음
        if (waypoints.Count == 0 || currentWaypointIndex >= waypoints.Count) return;

        //// 현재 웨이포인트로 이동
        Transform target = waypoints[currentWaypointIndex];
        Vector3 direction = target.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

        //// 애니메이션 파라미터 설정
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);

        //// 방향에 따라 스프라이트 반전
        if (direction.x < 0.1f)
            spriteRenderer.flipX = true;
        else if (direction.x > -0.1f)
            spriteRenderer.flipX = false;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
            currentWaypointIndex++;
    }

    bool DetectUnit()
    {
        //// 공격 범위 내에 유닛이 있는지 확인
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (var hit in hits)
        {
            // 유닛이 공격 범위 내에 있는지 확인
            if (hit.CompareTag("Unit"))
            {
                targetUnit = hit.gameObject;
                return true;
            }
        }

        //// 공격 범위 내에 유닛이 없으면 null로 설정
        targetUnit = null;
        return false;
    }

    void Attack()
    {
        // 공격 애니메이션 재생
        if (targetUnit != null)
        {
            Unit unit = targetUnit.GetComponent<Unit>();
            if (unit != null)
            {
                unit.TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // 공격 범위 시각화
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
