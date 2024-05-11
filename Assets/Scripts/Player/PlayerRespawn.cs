using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public PlayerStats playerStats;
    public float minYPosition = -5f; // Valor m�nimo de la posici�n Y para reaparecer


    //public LifesUI lifesUI;
    public List<GameObject> vidas = new List<GameObject>();
    private Vector3 inicio;
    private Rigidbody2D rb;
    private Vector3 respawnPosition; //Variable para guardar la posicion donde se quiere respawnear

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inicio = transform.position; //Se guarda la posición inicial en una variable para el primer respawn
        respawnPosition = inicio; //Se asigna la posición de inicio como primer respawn
        // Agregar los GameObjects correspondientes a la lista de vidas
        for (int i = 0; i < playerStats.maxLife; i++)
        {
            GameObject vida = vidas[i];
            vida.SetActive(false);
        }
        AgregarVidas();
    }

    private void Update()
    {
        if (transform.position.x > 5){
            respawnPosition.x = 5; //El respawn acorde a la posición se asigna así
        }
        else if (transform.position.x < 0){
            respawnPosition = inicio;
        }

        if (transform.position.y < minYPosition){
            // Si la posición Y del personaje es menor que el mínimo, inicia el proceso de reaparición
            Respawn(); 
        }
    }

    private void Respawn()
    {
        // Reposiciona al personaje en la posición de respawn
        transform.position = respawnPosition;
        rb.velocity = Vector2.zero; // Resetea la velocidad para evitar problemas de movimiento al reaparecer
        QuitarVidas();
    }

    public void AgregarVidas()
    {
        for (int i = 0; i < playerStats.life; i++)
        {
            GameObject vida = vidas[i];
            vida.SetActive(true);
        }
    }

    private void QuitarVidas()
    {
        playerStats.life--;
        // Eliminar el último GameObject de la lista de vidas o el penúltimo si el último no está activado
        
        if (playerStats.life > 0){
            GameObject vidaToRemove = vidas[playerStats.life];
            vidaToRemove.SetActive(false);
        } else {
            Debug.Log("Game Over");
        }
    }
}
