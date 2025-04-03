using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciarPelota : MonoBehaviour
{
    [SerializeField] GameObject parentPelota;

    private void OnCollisionEnter(Collision collision)
    {
        BallBounce.instance.isBallMoving = false;
        collision.gameObject.transform.parent = parentPelota.transform;
        collision.gameObject.transform.localPosition = new Vector3(0.1575899f, 0.01316581f, 1.55f);
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        VidasPuntos.instance.CambiarVidas(-1);
    }
    private void OnTriggerEnter(Collider trigerrition)
    {
        Destroy(trigerrition.gameObject);
    }

}
