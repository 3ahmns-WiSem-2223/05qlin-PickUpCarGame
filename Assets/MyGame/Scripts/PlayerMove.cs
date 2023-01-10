using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed;
    Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }
    

    private void FixedUpdate()
    {
        Vector2 movementDirection = new Vector2(movement.x, movement.y);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey("left shift"))
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }
    }
}
