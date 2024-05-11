using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonarTNT : MonoBehaviour
{
    public GameObject explosion;
    public float radius = 5f;
    public GameObject piedra;
    public PlayerStats playerStats;
    public GameObject textoConteo;
    private int cuentaAtras = 3;
    public GameObject textoInstrucciones;
    public AudioClip tntactivate;


    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player") && playerStats.hasTNT) {
            textoInstrucciones.GetComponent<TextMesh>().text = "Pulsa X para detonar";
        }
        if (other.CompareTag("Player")) {
            textoInstrucciones.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
    
        if (other.CompareTag("Player")) {
            textoInstrucciones.SetActive(false);
        }
    }

    public void Detonar()
    {
        //si el tag player esta tocando el colider de la tnt
        if ( GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            textoConteo.SetActive(true);

            GetComponent<AudioSource>().PlayOneShot(tntactivate);
            StartCoroutine(Contar());
            
        }

    }

    private IEnumerator Contar(){
        for (int i = cuentaAtras; i > 0; i--)
        {
            textoConteo.GetComponent<TextMesh>().text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        textoConteo.SetActive(false);
        Explotar();
    }

    private void Explotar()
    {
        
        explosion.SetActive(true);
        piedra.GetComponent<SpriteRenderer>().enabled = false;
        piedra.GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        playerStats.hasTNT = false;
        StartCoroutine(Esperar());
    }

    private IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.8f);
        explosion.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(explosion, 0.7f);
        Destroy(piedra);
        Destroy(gameObject);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(explosion.transform.position, radius);
    }




}
