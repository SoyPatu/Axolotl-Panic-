using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GoMenuUI : UIWindow
{
    public Button _yesButton;
    public Button _noButton;

    public void OnYesButtonClicked(int escena)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(escena);
        UIManager.Instance.HideWindow("MenuUI");
    }

    public void OnNoButtonClicked()
    {
        Time.timeScale = 0f;
        UIManager.Instance.HideWindow("GoMenuUI");
        UIManager.Instance.ShowWindow("PauseUI");   
    }
}
