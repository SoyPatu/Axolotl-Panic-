using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : UIWindow
{
    public Button _pauseButton;
    public Button _resumeButton;
    public Button _quitButton;
    

    public void Reanudar()
    {
        Time.timeScale = 1f;
        UIManager.Instance.HideWindow("PauseUI");
    }


    public void OnQuitButtonClicked()
    {
        Time.timeScale = 0f;
        Debug.Log("Quit button clicked");
        UIManager.Instance.HideWindow("PauseUI");
        UIManager.Instance.ShowWindow("GoMenuUI");
    }
}
