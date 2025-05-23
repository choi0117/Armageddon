using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    // 스테이지 선택 패널
    public GameObject stageSelectPanel;
    public string selectedStageName = "";

    // 스테이지 선택 텍스트
    public TextMeshProUGUI selectedStageTextTMP;
    public Image stagePreviewImage;

    public void ToggleStageSelectPanel()
    {
        // 스테이지 선택 패널 열기/닫기
        bool isActive = stageSelectPanel.activeSelf;
        stageSelectPanel.SetActive(!isActive);
    }

    public void SelectStage(string stageName)
    {
        // 스테이지 선택
        selectedStageName = stageName;
        Debug.Log("Selected Stage: " + selectedStageName);

        // 스테이지 선택 텍스트 업데이트
        if (selectedStageTextTMP != null)
        {
            selectedStageTextTMP.text = $"{selectedStageName}";
        }

        // 스테이지 미리보기 이미지 로드
        if (stagePreviewImage != null)
        {
            // 스테이지 미리보기 이미지 로드
            Sprite previewSprite = Resources.Load<Sprite>("StagePreviews/" + stageName);
            if (previewSprite != null)
            {
                stagePreviewImage.sprite = previewSprite;
                stagePreviewImage.enabled = true;
            }
            else
            {
                stagePreviewImage.sprite = null;
                stagePreviewImage.enabled = false;
            }
        }
    }

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
