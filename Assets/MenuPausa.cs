using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject MenuPause;
    [SerializeField] private GameObject btnPausa;

    private bool pausaJuego = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausaJuego)
            {
                resume();
            }else {
                pausa();            
            }
        }
    }

    public void pausa()
    {
        pausaJuego = true;
        Time.timeScale = 0f;
        btnPausa.SetActive(false);
        MenuPause.SetActive(true);
    }
    public void resume ()
    {
        pausaJuego=false;
        Time.timeScale = 1f;
        btnPausa.SetActive(true);
        MenuPause.SetActive(false);
    }

    public void Iniciar()
    {
        pausaJuego = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    public void Inicio()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
