using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Timer : MonoBehaviour
{
    public float totalTime; // Tiempo total del temporizador
    public TextMesh timerText; // Referencia al Texto de la interfaz de usuario
    public PlayerStats playerStats;
    public SpriteRenderer spriteRenderer;
    public Sprite spriterojo;
    public Sprite spriteazul;
    public GameObject clock;
    public GameObject player;


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
        timerText.text = Mathf.RoundToInt(playerStats.tiempoRestante).ToString();

        // Si el tiempo restante es menor o igual a cero, realiza acciones necesarias
        if (playerStats.tiempoRestante <= 0f)
        {
            playerStats.tiempoRestante = 0f;
            StartCoroutine(SinTiempo());
        }

        if (playerStats.tiempoRestante <= 15f)
        {
            //combierte en entero el tiempo restante
            if (Mathf.RoundToInt(playerStats.tiempoRestante) % 2 == 0)
                spriteRenderer.sprite = spriteazul;
            else
                spriteRenderer.sprite = spriterojo;

        }
    }

    public IEnumerator SinTiempo()
    {
        player.GetComponent<PlayerInput>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;   
        player.GetComponent<Rigidbody2D>().gravityScale = 0;     
        clock.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
