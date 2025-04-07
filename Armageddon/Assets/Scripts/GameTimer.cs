using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 게임 진행 시간을 표시하는 스크립트
public class GameTimer : MonoBehaviour
{
    // UI 텍스트 컴포넌트
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0f;

    void Update()
    {
        // 매 프레임마다 경과 시간을 업데이트
        elapsedTime += Time.deltaTime;

        // 경과 시간을 분과 초로 변환
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // UI 텍스트에 경과 시간을 표시
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
