
using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;

    private float tiempo = 0f;
    private bool activo = true;

    public float TiempoFinal { get; private set; }

    void Update()
    {
        if (!activo) return;

        tiempo += Time.deltaTime;

        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);

        textoTiempo.text = minutos.ToString("00") + ":" +
                           segundos.ToString("00");
    }

    public void Detener()
    {
        activo = false;
        TiempoFinal = tiempo;
    }
}
