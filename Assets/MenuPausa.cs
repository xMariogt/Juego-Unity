using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject MenuPause;
    [SerializeField] private GameObject btnPausa;

    public void pausa()
    {
        Time.timeScale = 0f;
        btnPausa.SetActive(false);
        MenuPause.SetActive(true);
    }
    public void resume ()
    {
        Time.timeScale = 1f;
        btnPausa.SetActive(true);
        MenuPause.SetActive(false);
    }

    public void Iniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    public void Inicio()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
