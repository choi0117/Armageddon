using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//설정 UI 관리 스크립트
public class SettingsUI : MonoBehaviour
{
    public GameObject settingsPanel;
    public Button settingsButton;
    public Button exitButton;
    public Slider volumeSlider;

    void Start()
    {
        // 설정 패널 비활성화
        settingsPanel.SetActive(false);

        // 버튼클릭 시 설정 패널 토글
        settingsButton.onClick.AddListener(ToggleSettingsPanel);
        exitButton.onClick.AddListener(ExitToLobby);

        // 슬라이더 값이 바뀔 때마다 볼륨 조절
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = AudioListener.volume;
    }

    void ToggleSettingsPanel()
    {
        // 설정 패널을 토글함
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    void SetVolume(float volume)
    {
        // 볼륨을 설정함
        AudioListener.volume = volume;
    }

    void ExitToLobby()
    {
        // 로비씬으로 이동
        SceneManager.LoadScene("Lobby");
    }
}
