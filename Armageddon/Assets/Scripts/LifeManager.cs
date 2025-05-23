using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// 생명 관리를 위한 스크립트
public class LifeManager : MonoBehaviour
{
    // 싱글톤 패턴을 사용하여 LifeManager 인스턴스를 관리
    public static LifeManager Instance;

    // 게임 오버 패널
    public GameObject GameoverPanel;

    // 게임 오버 상태
    private bool isGameover = false;

    // 현재 생명 수
    public int life = 10;
    public TextMeshProUGUI lifeText;

    private void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        // 생명 UI 초기화
        UpdateLifeUI();
    }

    public void ReduceLife(int amount)
    {
        // 생명 감소
        life -= amount;
        UpdateLifeUI();

        // 생명이 0 이하가 되면 게임 오버 처리
        if (life <= 0)
        {
            GameOver();
        }
    }

    void UpdateLifeUI()
    {
        // UI에 생명 수 업데이트
        lifeText.text = "Life: " + life;
    }

    void GameOver()
    {
        if (isGameover) return;

        isGameover = true;
        GameoverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}

