using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float totalTime = 90f; // Tiempo total del temporizador
    public TextMesh timerText; // Referencia al Texto de la interfaz de usuario
    public PlayerStats playerStats;

    void Start()
    {
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
            Debug.Log("Time's up!");
        }
    }
}
