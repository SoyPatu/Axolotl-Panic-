using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PauseButtonUI : UIWindow
{
    public Button _pauseButton;

    public TextMeshProUGUI cronometro;

    private float tiempo = 0f;
    private bool temporizadorActivo = true;

    void Update()
    {
        ActualizarTemporizador();
        ImprimirCronometro();
    }

    public void ActualizarTemporizador()
    {
        if (GameManager.Instance != null && GameManager.Instance.EstaMuerto())
        {
            temporizadorActivo = false;
        }

        if (temporizadorActivo)
        {
            tiempo += Time.deltaTime;
        }
    }

    public void ImprimirCronometro()
    {
        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);

        cronometro.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void Pausa()
    {
        Time.timeScale = 0f;

        UIManager.Instance.ShowWindow("PauseUI");
        UIManager.Instance.HideWindow("PauseButtonUI");
    }
}
