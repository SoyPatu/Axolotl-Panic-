using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : UIWindow
{
    [Header("Settings UI")]
    [SerializeField] private Slider _volumeSlider;

    public override void Initialize()
    {
        base.Initialize();
        _volumeSlider.onValueChanged.AddListener(GetOnVolumeChanged);

    }
    private void GetOnVolumeChanged(float value)
    {
        Debug.Log($"Volume changed to: {value}");
    }
}