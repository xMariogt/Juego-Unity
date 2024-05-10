using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonarTNT : MonoBehaviour
{
    public GameObject explosion;
    public float radius = 5f;
    public GameObject piedra;
    public PlayerStats playerStats;


    public void Detonar()
    {
        //si el tag player esta tocando el colider de la tnt
        if ( GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            StartCoroutine(EsperarTresSegundos());
        }

    }

    private IEnumerator EsperarTresSegundos()
    {
        // Esperar tres segundos
        yield return new WaitForSeconds(3f);
            explosion.SetActive(true);
            Destroy(piedra, 0.7f);
            playerStats.hasTNT = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

            foreach (Collider2D nearbyObject in colliders)
            {
                Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
                }
            }

            Destroy(gameObject);
            Destroy(explosion, 0.9f);
            
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(explosion.transform.position, radius);
    }




}
