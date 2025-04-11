using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 몬스터 스크립트
public class Monster : MonoBehaviour
{
    // 몬스터의 체력
    public int maxHp = 100;
    // 몬스터의 체력
    public int currentHp;

    public GameObject healthBarPrefab;
    private Image fillImage;
    private GameObject healthBarInstance;

    void Start()
    {
        // 체력 초기화
        currentHp = maxHp;

        // 체력바 생성
        if (healthBarPrefab != null)
        {
            // 체력바 프리팹을 인스턴스화
            healthBarInstance = Instantiate(healthBarPrefab, transform.position + Vector3.up * 1f, Quaternion.identity);
            // 체력바를 캔버스의 자식으로 설정
            healthBarInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);
            // 체력바의 위치를 몬스터의 위치에 맞게 조정
            fillImage = healthBarInstance.transform.Find("Fill").GetComponent<Image>();
        }
    }

    void Update()
    {
        // 체력바의 위치를 몬스터의 위치에 맞게 조정
        if (healthBarInstance != null)
        {
            // 체력바의 위치를 몬스터의 위치에 맞게 조정
            healthBarInstance.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 0.2f);
        }
    }

    public void TakeDamage(int damage)
    {
        // 데미지를 받아 체력을 감소시킴
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Die();
        }

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (fillImage != null)
        {
            fillImage.fillAmount = (float)currentHp / maxHp;
        }
    }

    void Die()
    {
        Destroy(healthBarInstance);
        Destroy(gameObject);
    }
}
