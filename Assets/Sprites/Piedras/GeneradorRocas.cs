using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GeneradorRocas : MonoBehaviour
{
    public Sprite[] spritesRocas; // Arreglo de sprites de rocas
    public float velocidadCaidaMin = 10f;
    public float velocidadCaidaMax = 20f;
    public float frecuenciaGeneracion = 0.000001f;
    public Vector2 areaGeneracion = new Vector2(-10f, 10f);
    public float pantallaOffset = 0.3f; // Offset para que las rocas empiecen fuera de la pantalla
    private float tiempoPrimeraGeneracion;
    private float tiempoUltimaGeneracion;

    private void Update()
    {   
        //que se genere solo durante 7 segundos
        if (Time.time > 7)
        {
            return;
        }
        if (Time.time > tiempoUltimaGeneracion + frecuenciaGeneracion)
        {
            GenerarRoca();
            tiempoUltimaGeneracion = Time.time;
        }
    }

    private void GenerarRoca()
    {
        // Seleccionar aleatoriamente un sprite de roca
        Sprite spriteRoca = spritesRocas[Random.Range(0, spritesRocas.Length)];
        float tamanioRoca = Random.Range(0.1f, 2f);
        

        // Calcular una posición aleatoria en la parte superior de la pantalla
        float posX = Random.Range(areaGeneracion.x, areaGeneracion.y);
        float posY = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, 1 + pantallaOffset, 0)).y;

        // Instanciar la roca en la posición calculada y con el sprite seleccionado
        GameObject nuevaRoca = new GameObject("Roca");
        nuevaRoca.AddComponent<BoxCollider2D>();
        BoxCollider2D collider = nuevaRoca.GetComponent<BoxCollider2D>();
        collider.size = spriteRoca.bounds.size / 2;

        nuevaRoca.AddComponent<SpriteRenderer>().sprite = spriteRoca;
        nuevaRoca.transform.position = new Vector3(posX, posY, 0);
        nuevaRoca.transform.localScale = new Vector3(tamanioRoca, tamanioRoca, 1);

        // Configurar velocidad de caída y rotación aleatoria
        Rigidbody2D rb = nuevaRoca.AddComponent<Rigidbody2D>();
        float velocidadCaida = Random.Range(velocidadCaidaMin, velocidadCaidaMax);
        rb.velocity = Vector2.down * velocidadCaida;

        // Rotar la roca aleatoriamente
        float rotacionZ = Random.Range(-45f, 45f);
        nuevaRoca.transform.rotation = Quaternion.Euler(0f, 0f, rotacionZ);
    }
}
