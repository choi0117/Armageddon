using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 유닛 수 관리 스크립트
public class UnitManager : MonoBehaviour
{
    // 유닛 수 관리하는 싱글톤 클래스
    public int maxUnits = 5;
    // 현재 유닛 수
    private int currentUnits = 0;

    public TMP_Text unitCountText;

    public static UnitManager Instance { get; private set; }

    void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance == null) Instance = this;
        // 이미 존재하는 경우 파괴
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
    }

    public bool CanPlaceUnit()
    {
        // 현재 유닛 수가 최대 유닛 수보다 적은지 확인
        return currentUnits < maxUnits;
    }

    public void AddUnit()
    {
        // 유닛 수 증가
        currentUnits++;
        UpdateUI();
    }

    public void RemoveUnit()
    {
        // 유닛 수 감소
        currentUnits--;
        UpdateUI();
    }

    void UpdateUI()
    {
        // UI 업데이트
        unitCountText.text = $"Uniy: {maxUnits - currentUnits}/{maxUnits}";
    }
}
