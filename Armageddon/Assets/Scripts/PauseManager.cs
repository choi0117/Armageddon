using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 게임을 일시 정지하는 스크립트
public class PauseManager : MonoBehaviour
{
    // 싱글톤 패턴을 사용하여 PauseManager 인스턴스를 관리
    public TextMeshProUGUI pauseButtonText;
    // 게임이 일시 정지 상태인지 여부를 나타내는 변수
    private bool isPaused = false;

    public void TogglePause()
    {
        // 게임이 일시 정지 상태인지 확인
        isPaused = !isPaused;

        if (isPaused)
        {
            // 게임을 일시 정지하고 UI 텍스트를 업데이트
            Time.timeScale = 0f;
            pauseButtonText.text = "II";
            Debug.Log("Game Paused");
        }
        else
        {
            // 게임을 재개하고 UI 텍스트를 업데이트
            Time.timeScale = 1f;
            pauseButtonText.text = "II";
            Debug.Log("Game Resumed");
        }
    }
}
