using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public static BallBounce instance;

    private Rigidbody ballRb; // Referencia al Rigidbody de la pelota

    public Vector3 initialVelocity;
    public bool isBallMoving;

    [SerializeField] private float speed;

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

    void Start()
    {
        // Obtener el Rigidbody al inicio
        ballRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isBallMoving)
        {
            LanzarBola();
        }

    }

    private void FixedUpdate()
    {
        if (isBallMoving)
        {
            Vector3 ballVelocity = ballRb.velocity.normalized;
            ballRb.velocity = ballVelocity * speed;
        }
    }

    private void LanzarBola()
    {
        transform.parent = null;
        ballRb.velocity = new Vector3(Random.Range(-1f, 1f), 1f, 0f);
        isBallMoving = true;
    }
}
