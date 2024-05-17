using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float totalTime; // Tiempo total del temporizador
    public TextMesh timerText; // Referencia al Texto de la interfaz de usuario
    public PlayerStats playerStats;

    void Start()
    {
        totalTime = playerStats.tiempoRestante;
        playerStats.tiempoRestante = totalTime; // Inicializar el tiempo restante
    }

    void Update()
    {
        // Restar tiempo
        playerStats.tiempoRestante -= Time.deltaTime;

        // Actualizar el Texto del temporizador
        timerText.text = "Tiempo: " + Mathf.RoundToInt(playerStats.tiempoRestante).ToString();

        // Si el tiempo restante es menor o igual a cero, realiza acciones necesarias
        if (playerStats.tiempoRestante <= 0f)
        {
            // Por ejemplo, aqu� podr�as disminuir las vidas del jugador o finalizar el juego
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
