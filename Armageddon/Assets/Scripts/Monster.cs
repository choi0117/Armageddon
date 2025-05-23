using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 몬스터 스크립트
public class Monster : MonoBehaviour
{
    // 몬스터의 체력
    public int maxHp = 100;
    // 몬스터의 현재 체력
    public int currentHp;
    // 몬스터 지급 코인 수량
    public int coinReward = 2;

    // 체력바 프리팹
    public GameObject healthBarPrefab;
    private Image fillImage;
    private GameObject healthBarInstance;

    void Start()
    {
        currentHp = maxHp;

        if (healthBarPrefab != null)
        {
            // 체력바 생성 및 캔버스에 붙이기
            healthBarInstance = Instantiate(healthBarPrefab, transform.position + Vector3.up * 1f, Quaternion.identity);
            healthBarInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);

            // 체력바 Fill 이미지 가져오기
            fillImage = healthBarInstance.transform.Find("Fill").GetComponent<Image>();
        }
    }

    void Update()
    {
        // 체력바 위치를 몬스터 위에 위치시키기
        if (healthBarInstance != null)
        {
            healthBarInstance.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 0.2f);
        }
    }

    void UpdateHealthBar()
    {
        // 체력바 업데이트
        if (fillImage != null)
        {
            fillImage.fillAmount = (float)currentHp / maxHp;
        }
    }

    public void TakeDamage(int damage)
    {
        // 몬스터가 피해를 입었을 때 호출되는 함수
        currentHp -= damage;
        UpdateHealthBar();

        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 몬스터가 다른 오브젝트와 충돌했을 때 호출되는 함수
        if (other.CompareTag("Endpoint"))
        {
            Die();
        }
    }

    void Die()
    {
        // 몬스터가 죽었을 때 코인 지급
        CoinManager.Instance.AddCoin(coinReward);

        // 체력바 제거
        if (healthBarInstance != null)
        {
            Destroy(healthBarInstance);
        }

        // 몬스터 제거
        Destroy(gameObject);
    }
}
