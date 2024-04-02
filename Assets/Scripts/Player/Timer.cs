using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f; // Tiempo total del temporizador
    private float timeRemaining; // Tiempo restante
    public TMP_Text timerText; // Referencia al Texto de la interfaz de usuario

    void Start()
    {
        timeRemaining = totalTime; // Inicializar el tiempo restante
    }

    void Update()
    {
        // Restar tiempo
        timeRemaining -= Time.deltaTime;

        // Actualizar el Texto del temporizador
        timerText.text = "Time: " + Mathf.RoundToInt(timeRemaining).ToString();

        // Si el tiempo restante es menor o igual a cero, realiza acciones necesarias
        if (timeRemaining <= 0f)
        {
            // Por ejemplo, aquí podrías disminuir las vidas del jugador o finalizar el juego
            Debug.Log("Time's up!");
        }
    }
}
