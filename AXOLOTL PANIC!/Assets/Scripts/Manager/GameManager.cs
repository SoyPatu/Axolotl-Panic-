
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Contador contador;
    private GameOverUI gameOverUI;

    private bool gameOver = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void PlayerDied()
    {
        if (gameOver) return;

        Debug.Log("Iniciando Game Over");

        if (contador == null)
        {
            Debug.LogError("ERROR: Contador no asignado");
            return;
        }

       

        if (UIManager.Instance == null)
        {
            Debug.LogError("ERROR: UIManager.Instance es NULL");
            return;
        }

        gameOver = true;

        contador.Detener();

        UIManager.Instance.ShowWindow("GameOverUI");

        Time.timeScale = 0f;

        Debug.Log("Game Over ejecutado correctamente");
    }

    public bool EstaMuerto()
    {
        return gameOver;
    }
}
