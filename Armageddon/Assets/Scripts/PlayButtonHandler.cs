using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonHandler : MonoBehaviour
{
    // Play 버튼이 눌리면 이 메서드를 호출
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Stage1");
    }
}
