using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public static PaddleMovement instance;

    public float moveSpeed = 10f; // Velocidad de movimiento de la nave

    private bool invertido;

    private float invertidoDuracion = 10f;

    // Valor 0 = Límite izquierda / Valor 1 = Límite derecha
    [SerializeField] private float[] limits;

    [SerializeField] private GameObject invertirPowerUp;

    //public float bounds = 9f;

    private float inputX; // Entrada horizontal

    private void Awake()
    {        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void FixedUpdate()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        // Obtener la entrada de las teclas A (izquierda) y D (derecha)
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (invertido == true)
        {
            moveInput = moveInput * -1;
        }

        // Mover la nave en el eje X
        Vector3 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x + moveInput * moveSpeed * Time.deltaTime, limits[0], limits[1]);
        transform.position = playerPosition;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("InvertidoPowerUp"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(InvertirControles());
        }
    }


    IEnumerator InvertirControles()
    {
        invertido = true;
        yield return new WaitForSeconds(invertidoDuracion);
        invertido = false;
        yield return null;
    }

    public void CrearPowerUp(Vector3 posicion)
    {
        if (Random.Range(0f, 1f) <= Random.Range(0.2f, 0.3f))
        {
            Instantiate(invertirPowerUp, posicion, Quaternion.identity);
        }
    }
}