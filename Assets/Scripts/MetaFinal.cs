using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaFinal : MonoBehaviour
{
    public PlayerStats playerStats;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            int tiempo = (int) math.round(playerStats.tiempoRestante);
            GameManager.instance.SetTiempoRestante(tiempo);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
