using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRespawn : MonoBehaviour
{
    public PlayerStats playerStats;
    public float minYPosition = -50f; // Valor m�nimo de la posici�n Y para reaparecer
    public Vector2 velocidadRebote; // Velocidad de rebote al ser golpeado
    public AudioClip sonidoMuerte;
     public AudioClip sonidoCaida;

    //public LifesUI lifesUI;
    public List<GameObject> vidas = new List<GameObject>();
    private Vector3 inicio;
    private Rigidbody2D rb;
    private Vector3 respawnPosition; //Variable para guardar la posicion donde se quiere respawnear
    private GameObject enemy;
    private bool canPlay = true;

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

        if (transform.position.y < -4.5 && canPlay && transform.position.y > minYPosition){
            GetComponent<PlayerInput>().enabled = false;
            canPlay = false;
            GetComponent<AudioSource>().PlayOneShot(sonidoCaida);
            StartCoroutine(PuedeReproducir());
        }
        else
        if (transform.position.y < minYPosition){
            // Si la posición Y del personaje es menor que el mínimo, inicia el proceso de reaparición
            Respawn(); 
            canPlay = false;
            
        }
    }

    private IEnumerator PuedeReproducir(){
        yield return new WaitForSeconds(4f);
        canPlay = true;
    }

    private void Respawn()
    {
        // Reposiciona al personaje en la posición de respawn
        this.GetComponent<PlayerInput>().enabled = true;
        transform.position = respawnPosition;
        rb.velocity = Vector2.zero; // Resetea la velocidad para evitar problemas de movimiento al reaparecer
        if (enemy != null)
            enemy.GetComponent<Collider2D>().enabled = true;
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


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")){ 
            enemy = other.gameObject;
            enemy.GetComponent<Collider2D>().enabled = false;
            Morir();
        }
    }

    public void Morir(){
        GetComponent<AudioSource>().PlayOneShot(sonidoMuerte);
        this.GetComponent<Animator>().SetTrigger("Die"); 
        this.GetComponent<PlayerInput>().enabled = false;
        StartCoroutine(AnimarMuerte());
    }

    public IEnumerator AnimarMuerte(){
        yield return new WaitForSeconds(2f);
        this.GetComponent<Animator>().SetTrigger("EndDie"); 
        Respawn();

    }



}
