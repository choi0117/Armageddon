using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유닛 배치 관리 스크립트
public class UnitPlacementManager : MonoBehaviour
{
    // 유닛 배치 관리하는 싱글톤 클래스
    public static UnitPlacementManager Instance;

    // 선택된 카드
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
            Destroy(gameObject);
        }
    }

    public GameObject GetSelectedUnitPrefab()
    {
        // 선택된 카드의 유닛 프리팹을 반환
        return selectedCard != null ? selectedCard.unitPrefab : null;
    }

    public int GetSelectedUnitCost()
    {
        // 선택된 카드의 코스트를 반환
        return selectedCard != null ? selectedCard.cost : 0;
    }

    public void SelectCard(UnitCard card)
    {
        // 카드 선택 시 호출되는 함수
        selectedCard = card;
    }

    // 실제 유닛 배치 함수 (예시)
    public void PlaceUnit(Vector3 position)
    {
        // 유닛 배치 시 호출되는 함수
        if (selectedCard == null || !UnitManager.Instance.CanPlaceUnit())
        {
            Debug.Log("유닛 배치 불가: 선택된 카드가 없거나 유닛 제한 초과");
            return;
        }

        // 유닛 배치 가능 여부 확인
        Instantiate(selectedCard.unitPrefab, position, Quaternion.identity);
        // 유닛 배치 후 카드 선택 해제
        UnitManager.Instance.AddUnit();
    }
}
