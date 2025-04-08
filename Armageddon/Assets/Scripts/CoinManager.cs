using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 코인 관리 스크립트
public class CoinManager : MonoBehaviour
{
    // 싱글톤 패턴을 사용하여 인스턴스를 관리
    public static CoinManager Instance;

    // 코인 수량
    public int coin = 5;
    public TextMeshProUGUI coinText;

    // 코인 UI 텍스트를 업데이트하는 메서드
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // 코인 UI 초기화
        UpdateCoinUI();
        StartCoroutine(AutoCoinIncrease());
    }

    // 코인 자동 증가 코루틴
    IEnumerator AutoCoinIncrease()
    {
        while (true)
        {
            // 2초마다 코인 증가
            yield return new WaitForSeconds(2f);
            // 코인 증가
            AddCoin(1);
        }
    }

    public void AddCoin(int amount)
    {
        // 코인 증가
        coin += amount;
        UpdateCoinUI();
    }

    public void SpendCoin(int amount)
    {
        // 코인 사용
        if (coin >= amount)
        {
            // 코인 감소
            coin -= amount;
            UpdateCoinUI();
        }
        else
        {
            // 코인 부족 시 처리
            Debug.Log("Not enough coins!");
        }
    }

    void UpdateCoinUI()
    {
        // 코인 UI 업데이트
        coinText.text = " " + coin.ToString();
    }
}
