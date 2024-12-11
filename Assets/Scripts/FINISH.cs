using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FINISH : MonoBehaviour
{
    public TextMeshProUGUI finishText; // Campo para el texto "FINISH".
    public AudioSource finishSound;   // Campo para el sonido.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica que sea el jugador.
        {
            finishText.gameObject.SetActive(true); // Muestra el texto.
            finishSound.Play();                   // Reproduce el sonido.
        }
    }
}
