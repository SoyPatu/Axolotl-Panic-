using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : UIWindow
{

    public void OnMenuButtonClicked(int escena)
    {
        SceneManager.LoadScene(escena);
        UIManager.Instance.HideWindow("MenuUI");
    }

    public void OnSettingsButtonClicked()
    {
        Debug.Log("Settings button clicked");

        UIManager.Instance.ShowWindow("SettingsUI");

    }

    public void OnCreditsButtonClicked()
    {
        Debug.Log("Credits button clicked");

        UIManager.Instance.ShowWindow("CreditsUI");

    }

}
