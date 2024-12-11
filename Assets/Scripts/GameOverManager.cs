using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject gameOverText; // Arrastra aquí el texto de "Game Over" en el Inspector
    public Transform player;        // Arrastra aquí el objeto del jugador
    public Vector3 respawnPosition; // Define la posición inicial del personaje

    private void Start()
    {
        // Asegúrate de que el texto esté desactivado al inicio
        gameOverText.SetActive(false);
        // Guarda la posición inicial del personaje
        respawnPosition = player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            // Muestra el texto de "Game Over"
            gameOverText.SetActive(true);

            // Inicia una corrutina para reiniciar la posición después de un tiempo
            StartCoroutine(RestartPlayer());
        }
    }

    private System.Collections.IEnumerator RestartPlayer()
    {
        // Espera 2 segundos para que el jugador vea el mensaje
        yield return new WaitForSeconds(2f);

        // Oculta el texto de "Game Over"
        gameOverText.SetActive(false);

        // Regresa al personaje a la posición inicial
        player.position = respawnPosition;
    }
}
