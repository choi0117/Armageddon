using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유닛 배치 관리 스크립트
public class UnitPlacementManager : MonoBehaviour
{
    public static UnitPlacementManager Instance;

    // 유닛 카드 프리팹
    [HideInInspector]
    public UnitCard selectedCard;

    private void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // 이미 인스턴스가 존재하는 경우 현재 오브젝트 삭제
            Destroy(gameObject);
        }
    }

    // 유닛 프리팹 가져오기
    public GameObject GetSelectedUnitPrefab()
    {
        return selectedCard != null ? selectedCard.unitPrefab : null;
    }

    // 유닛 코스트 가져오기
    public int GetSelectedUnitCost()
    {
        return selectedCard != null ? selectedCard.cost : 0;
    }

    // 카드 선택 메서드
    public void SelectCard(UnitCard card)
    {
        selectedCard = card;
    }
}
