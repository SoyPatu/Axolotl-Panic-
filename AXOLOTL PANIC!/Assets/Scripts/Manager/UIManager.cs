
using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<UIWindow> _uiWindows;

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ShowWindow(string windowName)
    {
        UIWindow selectedWindow = null;

        // Buscar la ventana que queremos abrir
        foreach (UIWindow window in _uiWindows)
        {
            if (window != null && window.WindowId == windowName)
            {
                selectedWindow = window;
                break;
            }
        }

        // Comprobar que la ventana existe
        if (selectedWindow == null)
        {
            Debug.LogWarning("No se encontró la ventana: " + windowName);
            return;
        }

        // Ocultar las demás ventanas
        foreach (UIWindow window in _uiWindows)
        {
            if (window != null && window != selectedWindow)
            {
                window.Hide();
            }
        }

        // Mostrar la ventana seleccionada
        selectedWindow.Show();
    }

    public void HideWindow(string windowName)
    {
        foreach (UIWindow window in _uiWindows)
        {
            if (window != null && window.WindowId == windowName)
            {
                window.Hide();
                return;
            }
        }

        Debug.LogWarning("No se encontró la ventana: " + windowName);
    }
}
