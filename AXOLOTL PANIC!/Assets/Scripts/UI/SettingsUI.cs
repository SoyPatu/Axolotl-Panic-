
using Dino.Utility.Audio;
using UnityEngine;
using UnityEngine.UI;
using AudioType = Dino.Utility.Audio.AudioType;

public class SettingsUI : UIWindow
{
    [Header("Volume Sliders")]
    [SerializeField] private Slider _volumeSFXSlider;
    [SerializeField] private Slider _volumeMusicSlider;

    public Button _returnButton;

    public override void Initialize()
    {
        base.Initialize();

        // Comprobar que los sliders estén asignados.
        if (_volumeSFXSlider == null)
        {
            Debug.LogError("Falta asignar el slider SFX");
            return;
        }

        if (_volumeMusicSlider == null)
        {
            Debug.LogError("Falta asignar el slider Music");
            return;
        }

        // Configurar los valores iniciales.
        _volumeSFXSlider.minValue = 0f;
        _volumeSFXSlider.maxValue = 1f;

        _volumeMusicSlider.minValue = 0f;
        _volumeMusicSlider.maxValue = 1f;

        // Cargar los volúmenes guardados.
        _volumeSFXSlider.value = GetFloat("SFXVolume");
        _volumeMusicSlider.value = GetFloat("MusicVolume");

        // Conectar los sliders.
        _volumeSFXSlider.onValueChanged.RemoveListener(
            OnVolumeSFXSliderChanged);

        _volumeMusicSlider.onValueChanged.RemoveListener(
            OnVolumeMusicSliderChanged);

        _volumeSFXSlider.onValueChanged.AddListener(
            OnVolumeSFXSliderChanged);

        _volumeMusicSlider.onValueChanged.AddListener(
            OnVolumeMusicSliderChanged);

        // Aplicar los volúmenes al Audio Mixer.
        OnVolumeSFXSliderChanged(_volumeSFXSlider.value);
        OnVolumeMusicSliderChanged(_volumeMusicSlider.value);
    }

    public float GetFloat(string KeyName)
    {
        return PlayerPrefs.GetFloat(KeyName, 0f); // Valor por defecto 0.5 si no existe la clave
    }

    private void OnVolumeSFXSliderChanged(float volume)
    {
        Debug.Log($"SFX Volume changed to: {volume}");

        if (AudioManager.Instance == null)
        {
            Debug.LogError("No se encontró el AudioManager");
            return;
        }

        AudioManager.Instance.UpdateAudioMixerGroupVolume(
            volume, AudioType.SFX);

        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }

    private void OnVolumeMusicSliderChanged(float volume)
    {
        Debug.Log($"Music Volume changed to: {volume}");

        if (AudioManager.Instance == null)
        {
            Debug.LogError("No se encontró el AudioManager");
            return;
        }

        AudioManager.Instance.UpdateAudioMixerGroupVolume(volume, AudioType.Music);

        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public void OnReturnButtonClicked()
    {
        Debug.Log("Return button clicked");

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowWindow("MenuUI");
        }
        else
        {
            Debug.LogError("No se encontró el UIManager");
        }
    }
}
