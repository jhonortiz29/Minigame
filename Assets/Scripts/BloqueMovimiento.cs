using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueMovimiento : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad del movimiento
    public float distancia = 2f; // Distancia m�xima del movimiento en el eje Z

    private Vector3 posicionInicial; // Posici�n inicial del bloque

    void Start()
    {
        // Guarda la posici�n inicial del bloque
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcula el desplazamiento hacia adelante y atr�s usando una onda seno
        float desplazamiento = Mathf.Sin(Time.time * velocidad) * distancia;

        // Aplica el desplazamiento a la posici�n inicial en el eje Z
        transform.position = new Vector3(posicionInicial.x, posicionInicial.y, posicionInicial.z + desplazamiento);
    }
}
