using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAppear : MonoBehaviour
{
    public float velocidadCrecimiento = 1f; // Velocidad a la que la espada crecerá
    public float escalaFinal = 1f; // Escala final de la espada
    public float distanciaFinal = 5f; // Distancia final desde la cámara

    private Vector3 escalaInicial; // Escala inicial del objeto
    private Vector3 posicionInicial; // Posición inicial del objeto

    private void Start()
    {
        // Guardar la escala y posición inicial del objeto
        escalaInicial = transform.localScale;
        posicionInicial = transform.position;

        //hacer que inicialmente no sea visible
        transform.localScale = Vector3.zero;

    }

    // Método que inicia la animación de la espada saliendo del cofre
    public void SalirDelCofre()
    {
        // Iniciar una corrutina para animar el crecimiento de la espada
        StartCoroutine(CrecerEspada());
    }

    private IEnumerator CrecerEspada()
    {
        // Mientras la espada no haya alcanzado la escala y la posición final
        while (transform.localScale.x < escalaFinal)
        {
            // Incrementar gradualmente la escala de la espada
            transform.localScale += Vector3.one * velocidadCrecimiento * Time.deltaTime;

            // Mover la espada hacia la cámara
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, velocidadCrecimiento * Time.deltaTime);

            yield return null; // Esperar un frame antes de continuar
        }

        // Una vez alcanzada la escala y la posición final, fijar la posición final
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * distanciaFinal;
    }

    // Método para reiniciar la posición y escala de la espada
    public void ReiniciarEspada()
    {
        transform.localScale = escalaInicial;
        transform.position = posicionInicial;
    }
}
