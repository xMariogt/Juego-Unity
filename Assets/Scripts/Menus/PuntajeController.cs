using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeController : MonoBehaviour
{

    public TextMeshProUGUI puntaje;
    private void Update() {
        
        int tiempoRestante = GameManager.instance.GetTiempoRestante();
        Debug.Log(tiempoRestante);
        puntaje.text = " " + tiempoRestante + " ";
    }
}
