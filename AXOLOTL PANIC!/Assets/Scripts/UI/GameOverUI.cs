
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : UIWindow
{
    private Contador contador;

    public TextMeshProUGUI resultado;
    public TextMeshProUGUI highScoreText;


    public void MostrarResultado()
    {
        if (contador == null)
        {
            Debug.LogError("No se asignó el Contador");
            return;
        }

        float tiempo = contador.TiempoFinal;

        Debug.Log("MostrarResultado ejecutado. Tiempo: " + tiempo);

        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);

        resultado.text = minutos.ToString("00") + ":" +
                         segundos.ToString("00");

        GuardarHighScore();
        MostrarHighScore();
    }


    public void GuardarHighScore()
    {
        float tiempoActual = contador.TiempoFinal;
        float highScore = PlayerPrefs.GetFloat("HighScore", 0f);

        if (tiempoActual > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", tiempoActual);
            PlayerPrefs.Save();
        }
    }

    public void MostrarHighScore()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore", 0f);

        highScoreText.text = "HIGH SCORE: " +
                             FormatoTiempo(highScore);
    }

    private string FormatoTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);

        return minutos.ToString("00") + ":" +
               segundos.ToString("00");
    }

    public void OnTryAgainButtonClicked(int escena)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(escena);
        UIManager.Instance.HideWindow("GameOverUI");
    }

    public void OnMenuButtonClicked(int escena)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(escena);
        UIManager.Instance.HideWindow("GameOverUI");
    }
}
