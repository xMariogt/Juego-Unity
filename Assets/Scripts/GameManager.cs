using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     public static GameManager instance;

    public int tiempoRestante;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetTiempoRestante(int tiempo)
    {
        tiempoRestante = tiempo;
    }

    public int GetTiempoRestante()
    {
        return tiempoRestante;
    }
}
