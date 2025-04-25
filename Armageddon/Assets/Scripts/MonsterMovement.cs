using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스트 이동을 관리하는 스크립트
public class MonsterMovement : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed = 0.6f;
    private int currentWaypointIndex = 0;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // 공격 관련
    public float attackRange = 0.5f;
    public float attackCooldown = 1.5f;
    public int attackDamage = 10;
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
        if (waypoints.Count == 0 || currentWaypointIndex >= waypoints.Count) return;

        Transform target = waypoints[currentWaypointIndex];
        Vector3 direction = target.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);

        if (direction.x < 0.1f)
            spriteRenderer.flipX = true;
        else if (direction.x > -0.1f)
            spriteRenderer.flipX = false;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
            currentWaypointIndex++;
    }

    bool DetectUnit()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Unit"))
            {
                targetUnit = hit.gameObject;
                return true;
            }
        }

        targetUnit = null;
        return false;
    }

    void Attack()
    {
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
