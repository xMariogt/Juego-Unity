using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento del canvas
    public float tiempoEspera = 5f; // Tiempo de espera en la posición superior
    public Transform jugador; // Referencia al objeto que seguirá el canvas

    private RectTransform canvasRectTransform;
    private Vector2 posicionInicial;
    private Vector2 posicionSuperior;
    private bool moviendose = false;

    public void ShowMessage()
    {
        // Obtenemos el RectTransform del canvas
        canvasRectTransform = GetComponent<RectTransform>();

        // Guardamos la posición inicial y la posición superior
        posicionInicial = canvasRectTransform.anchoredPosition;
        posicionSuperior = new Vector2(0f, -154.01f); // Coordenada Y constante en -154.01

        // Iniciamos la corutina de movimiento
        StartCoroutine(MoverCanvas());
    }

    private IEnumerator MoverCanvas()
    {
        while (true)
        {
            // Obtenemos la posición X del jugador
            float posX = jugador.position.x;

            // Movemos el canvas hacia la posición superior
            moviendose = true;
            while (Vector2.Distance(canvasRectTransform.anchoredPosition, posicionSuperior) > 0.1f)
            {
                Vector2 targetPosition = new Vector2(posX, posicionSuperior.y);
                canvasRectTransform.anchoredPosition = Vector2.Lerp(canvasRectTransform.anchoredPosition, targetPosition, Time.deltaTime * velocidadMovimiento);
                yield return null;
            }

            // Esperamos en la posición superior
            yield return new WaitForSeconds(tiempoEspera);

            // Movemos el canvas de regreso a la posición inicial
            moviendose = false;
            while (Vector2.Distance(canvasRectTransform.anchoredPosition, posicionInicial) > 0.1f)
            {
                Vector2 targetPosition = new Vector2(posX, posicionInicial.y);
                canvasRectTransform.anchoredPosition = Vector2.Lerp(canvasRectTransform.anchoredPosition, targetPosition, Time.deltaTime * velocidadMovimiento);
                yield return null;
            }
        }
    }
}
