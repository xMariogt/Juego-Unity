using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour
{
    public GameObject message;
    public Transform jugador;
    public float duracionAnimacion = 0.5f; // Duración de la animación de transición
    public float tiempoEspera = 5f; // Tiempo de espera antes de ocultar el mensaje
    private float altura;
    private Coroutine mostrarCoroutine;
    private Coroutine ocultarCoroutine;


    private void Start() {
        altura = message.transform.position.y;
    }
    public void ShowMessage()
    {
        GetComponent<AudioSource>().Play();
        if (mostrarCoroutine != null)
        {
            StopCoroutine(mostrarCoroutine);
        }
        if (ocultarCoroutine != null)
        {
            StopCoroutine(ocultarCoroutine);
        }
        mostrarCoroutine = StartCoroutine(moverAbajo());
    }

    public void HideMessage()
    {
        if (mostrarCoroutine != null)
        {
            StopCoroutine(mostrarCoroutine);
        }
        if (ocultarCoroutine != null)
        {
            StopCoroutine(ocultarCoroutine);
        }
        ocultarCoroutine = StartCoroutine(moverArriba());
    }

    private IEnumerator moverAbajo()
    {
        Vector3 posicionInicial = message.transform.position;
        Vector3 posicionFinal = new Vector3(message.transform.position.x, altura - 0.5f, message.transform.position.z);
        float tiempoPasado = 0f;

        while (tiempoPasado < duracionAnimacion)
        {
            tiempoPasado += Time.deltaTime;
            float t = Mathf.Clamp01(tiempoPasado / duracionAnimacion);
            message.transform.position = Vector3.Lerp(posicionInicial, posicionFinal, t);
            yield return null;
        }

        message.transform.position = posicionFinal;

        yield return new WaitForSeconds(tiempoEspera);

        ocultarCoroutine = StartCoroutine(moverArriba());
    }

    private IEnumerator moverArriba()
    {
        Vector3 posicionInicial = message.transform.position;
        Vector3 posicionFinal = new Vector3(message.transform.position.x, altura + 0.5f, message.transform.position.z);
        float tiempoPasado = 0f;

        while (tiempoPasado < duracionAnimacion)
        {
            tiempoPasado += Time.deltaTime;
            float t = Mathf.Clamp01(tiempoPasado / duracionAnimacion);
            posicionFinal.Set(message.transform.position.x, posicionFinal.y, posicionFinal.z);
            message.transform.position = Vector3.Lerp(posicionInicial, posicionFinal, t);
            yield return null;
        }

        message.transform.position = posicionFinal;
        Destroy(message);
    }

   
}
