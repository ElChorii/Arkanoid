using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladrillos : MonoBehaviour
{
    [SerializeField] private int vidaLadrillo = 1;
    [SerializeField] private int puntosLaddrillo = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            vidaLadrillo--;

            if (vidaLadrillo <= 0)
            {
                VidasPuntos.instance.SumarPuntos(puntosLaddrillo);
                PaddleMovement.instance.CrearPowerUp(transform.position);
                Destroy(gameObject);
            }
        }
    }
}
