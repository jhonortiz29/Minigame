using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public Transform player; // Referencia al jugador que seguir� la c�mara
    public Vector3 camOffset; // Desplazamiento inicial de la c�mara respecto al jugador

    [Range(0.1f, 1.0f)]
    public float SmoothFactor = 0.1f; // Suavidad para el movimiento de la c�mara

    public bool rotationActive = true;
    public float velRotacion = 5.0f; // Velocidad de rotaci�n

    public bool lookAtPlayer = false;

    private float verticalAngle = 0.0f; // Para manejar el �ngulo vertical acumulado
    public float verticalLimit = 80.0f; // L�mite del �ngulo vertical (para evitar giros extremos)

    private void Start()
    {
        camOffset = transform.position - player.position; // Desplazamiento inicial
    }

    private void FixedUpdate()
    {
        if (rotationActive)
        {
            // Obtener el movimiento del mouse
            float mouseX = Input.GetAxis("Mouse X") * velRotacion;
            float mouseY = Input.GetAxis("Mouse Y") * velRotacion;

            // Rotaci�n horizontal (eje Y del mundo)
            Quaternion camTurnAngleX = Quaternion.AngleAxis(mouseX, Vector3.up);

            // Rotaci�n vertical (eje X de la c�mara)
            verticalAngle -= mouseY;
            verticalAngle = Mathf.Clamp(verticalAngle, -verticalLimit, verticalLimit);
            Quaternion camTurnAngleY = Quaternion.AngleAxis(verticalAngle, Vector3.right);

            // Aplicar rotaciones acumuladas
            camOffset = camTurnAngleX * camOffset;

            // Rotar la c�mara alrededor del jugador
            transform.rotation = Quaternion.Euler(verticalAngle, transform.eulerAngles.y + mouseX, 0);
        }

        // Posicionar la c�mara detr�s del jugador con suavidad
        Vector3 newPos = player.position + camOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        // Mirar al jugador si est� activado
        if (lookAtPlayer)
        {
            transform.LookAt(player);
        }
    }






}
