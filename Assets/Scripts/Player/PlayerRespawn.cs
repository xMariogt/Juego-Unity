using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float minYPosition = -5f; // Valor mínimo de la posición Y para reaparecer

    private Vector3 inicio;
    private Rigidbody2D rb;
    private Vector3 respawnPosition; //Variable para guardar la posicion donde se quiere respawnear

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inicio = transform.position; //Se guarda la posicion inicial en una variable para el primer respawn
        respawnPosition = inicio; //Se asigna la posicion de inicio como primer respawn
    }

    private void Update()
    {
        if(transform.position.x > 6)
        {
            respawnPosition.x = 6; //El respawn acorde a la posicion se asigna asi

        }else if(transform.position.x < 0)
        {
            respawnPosition = inicio;
        }


        if (transform.position.y < minYPosition)
        {
            // Si la posición Y del personaje es menor que el mínimo, inicia el proceso de reaparición
            Respawn();
        }
    }

    private void Respawn()
    {
        // Reposiciona al personaje en la posición de respawn
        transform.position = respawnPosition;
        rb.velocity = Vector2.zero; // Resetea la velocidad para evitar problemas de movimiento al reaparecer
    }
}
