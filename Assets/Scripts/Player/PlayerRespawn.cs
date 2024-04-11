using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float minYPosition = -5f; // Valor m�nimo de la posici�n Y para reaparecer

    //Control de las vidas
    public int currentLives;
    public int maxLives = 5;
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

        currentLives = maxLives;
        // Agregar los GameObjects correspondientes a la lista de vidas
        AgregarVidas();
    }

    private void Update()
    {
        if (transform.position.x > 5)
        {
            respawnPosition.x = 5; //El respawn acorde a la posición se asigna así

        }
        else if (transform.position.x < 0)
        {
            respawnPosition = inicio;
        }


        if (transform.position.y < minYPosition)
        {
            // Si la posición Y del personaje es menor que el mínimo, inicia el proceso de reaparición
            Respawn();
            currentLives--;
        }
    }

    private void Respawn()
    {
        // Reposiciona al personaje en la posición de respawn
        transform.position = respawnPosition;
        rb.velocity = Vector2.zero; // Resetea la velocidad para evitar problemas de movimiento al reaparecer

        QuitarVidas();
    }

    private void AgregarVidas()
    {
        for (int i = 0; i < maxLives; i++)
        {
            GameObject vida = vidas[i];
            vida.SetActive(i < maxLives - 1); // Desactiva el último GameObject
        }
    }

    private void QuitarVidas()
    {
        // Eliminar el último GameObject de la lista de vidas o el penúltimo si el último no está activado
        int indiceInicio = (vidas.Count == maxLives && !vidas[maxLives - 1].activeSelf) ? maxLives - 2 : maxLives - 1;
        if (currentLives > 0 && currentLives <= vidas.Count)
        {
            GameObject vidaToRemove = vidas[indiceInicio];
            vidas.Remove(vidaToRemove);
            Destroy(vidaToRemove);
        }
    }
}
