using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 180f;
    public float drag = 0.5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical);

        rb.AddForce(direction * speed);
        rb.AddForce(-rb.velocity * drag);

        if (horizontal != 0f || vertical != 0f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.forward, direction), rotationSpeed * Time.deltaTime);
        }
    }
}
