using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 유닛 배치 필드 타일 스크립트
public class FieldTile : MonoBehaviour
{
    // 필드 타일이 점령되었는지 여부
    public bool isOccupied = false;
    // 필드 타일의 색상
    private SpriteRenderer spriteRenderer;
    // 원래 색상
    private Color originalColor;

    private void Start()
    {
        // 필드 타일의 스프라이트 렌더러 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 원래 색상 저장
        originalColor = spriteRenderer.color;
    }

    private void OnMouseEnter()
    {
        // 마우스가 필드 타일 위에 있을 때
        if (!isOccupied && !EventSystem.current.IsPointerOverGameObject())
        {
            // 필드 타일이 점령되지 않았고 UI 위에 마우스가 없을 때 색상 변경
            spriteRenderer.color = Color.green;
        }
    }

    private void OnMouseExit()
    {
        // 마우스가 필드 타일에서 나갈 때
        spriteRenderer.color = originalColor;
    }

    private void OnMouseDown()
    {
        // 마우스 클릭 시
        if (EventSystem.current.IsPointerOverGameObject()) return;
        // UI 위에 마우스가 없을 때
        if (isOccupied) return;
        // 이미 점령된 필드 타일 클릭 시 아무것도 하지 않음
        if (UnitPlacementManager.Instance == null) return;

        // 유닛 프리팹과 코스트 가져오기
        GameObject unitPrefab = UnitPlacementManager.Instance.GetSelectedUnitPrefab();
        // 유닛 코스트 가져오기
        int cost = UnitPlacementManager.Instance.GetSelectedUnitCost();

        // 유닛 프리팹이 null이 아니고 코스트가 충분할 때
        if (unitPrefab != null && CoinManager.Instance.coin >= cost)
        {
            // 유닛 프리팹을 필드 타일에 소환
            Instantiate(unitPrefab, transform.position, Quaternion.identity);
            // 필드 타일 점령
            CoinManager.Instance.SpendCoin(cost);
            // 코인 소모
            isOccupied = true;
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }
}
