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
    private int CuentaAtras = 3;
    public GameObject textoInstrucciones;
    public AudioClip tntactivate;
    public AudioClip audioConteo;


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
            textoInstrucciones.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = true;
            textoConteo.SetActive(true);

            GetComponent<AudioSource>().PlayOneShot(tntactivate);
            StartCoroutine(ActivarTNT());
            
        }

    }

    private IEnumerator ActivarTNT(){
        for (int i = CuentaAtras; i > 0; i--)
        {
            textoConteo.GetComponent<TextMesh>().text = i.ToString();
            yield return new WaitForSeconds(1f);
            GetComponent<AudioSource>().PlayOneShot(audioConteo);
        }
        textoConteo.SetActive(false);
        IniciaExplosion();
    }

    private void IniciaExplosion()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosion.transform.position, radius);
        foreach (Collider2D nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Player"))
            {
                nearbyObject.GetComponent<PlayerRespawn>().Morir();
            }
            
        }
        explosion.SetActive(true);
        piedra.GetComponent<SpriteRenderer>().enabled = false;
        piedra.GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        playerStats.hasTNT = false;
        StartCoroutine(EsperaExplosion());
    }

    private IEnumerator EsperaExplosion()
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
