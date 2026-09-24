using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<UIWindow> _uiWindows;

    void Start()
    {
        
    }

    public void ShowWindow(string windowName)
    {
        foreach (var window in _uiWindows)
        {
            if (window.WindowId == windowName)
            {
                window.Show();
                return;
            }
        }
    }

    public void HideWindow(string windowName)
    {
        foreach (var window in _uiWindows)
        {
            if (window.WindowId == windowName)
            {
                window.Hide();
                return;
            }
        }
    }
}
