using UnityEditor;
using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    void Start()
    {
        StartCoroutine(MiCorrutina());
    }
    IEnumerator MiCorrutina()
    {
        Debug.Log("Inicio de la corrutina");

        // Pausar la ejecución durante 2 segundos
        yield return new WaitForSeconds(1f);

        Debug.Log("Han pasado 2 segundos");

        UIManager.Instance.ShowWindow("MenuUI");


    }


}
