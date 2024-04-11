using UnityEngine;

public class ItemsCollect : MonoBehaviour
{/*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActivarUltimoElemento();
            Destroy(gameObject); // Destruye el objeto con el que colisiona
            Debug.Log("Se elimina");
        }
    }
    
    private void ActivarUltimoElemento()
    {
        // Encuentra el objeto PlayerRespawn en la escena
        PlayerRespawn playerRespawn = FindObjectOfType<PlayerRespawn>();
        if (playerRespawn != null && playerRespawn.vidas.Count > 0)
        {
            // Activa el último elemento de la lista
            GameObject ultimoElemento = playerRespawn.vidas[playerRespawn.vidas.Count - 1];
            ultimoElemento.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No se encontró el objeto PlayerRespawn o la lista de vidas está vacía.");
        }
    }*/
}
