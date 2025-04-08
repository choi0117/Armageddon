using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 유닛 카드 스크립트
public class UnitCard : MonoBehaviour
{
    // 카드가 소환할 유닛 프리팹 (프리팹을 드래그해서 연결할 수 있도록 public으로 설정)
    public GameObject unitPrefab;

    // 카드가 사용할 코스트
    public int cost;

    // 카드 버튼
    private Button button;

    private void Awake()
    {
        // 버튼 컴포넌트 가져오기
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickCard);
    }

    void OnClickCard()
    {
        // 카드 클릭 시 유닛 배치 매니저에 카드 선택 요청
        UnitPlacementManager.Instance.SelectCard(this);
    }
}
