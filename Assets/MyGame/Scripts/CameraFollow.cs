using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothspeed = 10f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothspeed);
        transform.position = smoothedPos;
    }
}
