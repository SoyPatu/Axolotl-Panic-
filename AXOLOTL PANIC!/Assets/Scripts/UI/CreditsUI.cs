using UnityEngine;
using UnityEngine.UI;

public class CreditsUI : UIWindow
{
    public Button _returnButton;

    public void OnReturnButtonClicked()
    {
        Debug.Log("Return button clicked");

        UIManager.Instance.ShowWindow("MenuUI");
    }

}
