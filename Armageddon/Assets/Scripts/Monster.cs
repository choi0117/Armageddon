using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 몬스터 스크립트
public class Monster : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp;

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
        if (fillImage != null)
        {
            fillImage.fillAmount = (float)currentHp / maxHp;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        UpdateHealthBar();

        if (currentHp <= 0)
        {
            Die(); // <- 여기서 Die() 호출되도록 수정!
        }
    }

    void Die()
    {
        // 체력바 먼저 제거
        if (healthBarInstance != null)
        {
            Destroy(healthBarInstance);
        }

        // 몬스터 오브젝트 제거
        Destroy(gameObject);
    }
}
