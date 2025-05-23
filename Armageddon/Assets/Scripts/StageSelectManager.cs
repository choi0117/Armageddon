using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageSelectManager : MonoBehaviour
{
    public GameObject stageSelectPanel;
    public string selectedStageName = "";

    public TextMeshProUGUI selectedStageTextTMP;

    // STAGE 버튼 클릭 시 호출
    public void ToggleStageSelectPanel()
    {
        bool isActive = stageSelectPanel.activeSelf;
        stageSelectPanel.SetActive(!isActive);
    }

    // 스테이지 선택 버튼 클릭 시 호출
    public void SelectStage(string stageName)
    {
        selectedStageName = stageName;
        Debug.Log("Selected Stage: " + selectedStageName);

        if (selectedStageTextTMP != null)
        {
            selectedStageTextTMP.text = $"{selectedStageName}";
        }
    }

    // PLAY 버튼 클릭 시 호출
    public void PlaySelectedStage()
    {
        if (!string.IsNullOrEmpty(selectedStageName))
        {
            SceneManager.LoadScene(selectedStageName);
        }
        else
        {
            Debug.LogWarning("스테이지를 먼저 선택하세요.");
        }
    }
}
