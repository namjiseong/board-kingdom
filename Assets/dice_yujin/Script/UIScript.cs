using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject SettingsUI;
    public GameObject StageUI;
    public void OnClickNewGame()
    {
        MainUI.SetActive(false);
        StageUI.SetActive(true);
        //새 게임
    }
    public void OnClickLoad()
    {
        //저장파일 유무
        //로드파일
        MainUI.SetActive(false);
    }
    public void OnClickSettings()
    {
        SettingsUI.SetActive(true);
    }
    public void OnClickQuit()
    {
        //저장할지 확인 후
        QuitGame();
    }
    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
