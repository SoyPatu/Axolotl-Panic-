using Dino.Utility.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;
using AudioType = Dino.Utility.Audio.AudioType;

public class SettingsUI : UIWindow
{
    [SerializeField] private Slider _volumeSFXSlider;
    [SerializeField] private Slider _volumeMusicSlider;

    public override void Initialize()
    {
        base.Initialize();
        _volumeSFXSlider.onValueChanged.AddListener(OnVolumeSFXSliderChanged);
        _volumeMusicSlider.onValueChanged.AddListener(OnVolumeMusicSliderChanged);
    }

    private void OnVolumeSFXSliderChanged(float volume)
    {
        Debug.Log($"SFX Volume changed to: {volume}");
        AudioManager.Instance.UpdateAudioMixerGroupVolume(volume, AudioType.SFX);
    }

    private void OnVolumeMusicSliderChanged(float volume)
    {
        Debug.Log($"Music Volume changed to: {volume}");
        AudioManager.Instance.UpdateAudioMixerGroupVolume(volume, AudioType.Music);
    }

}