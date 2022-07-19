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
        //�� ����
    }
    public void OnClickLoad()
    {
        //�������� ����
        //�ε�����
        MainUI.SetActive(false);
    }
    public void OnClickSettings()
    {
        SettingsUI.SetActive(true);
    }
    public void OnClickQuit()
    {
        //�������� Ȯ�� ��
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
