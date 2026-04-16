using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothVelocity = 0.13f;
    public Transform playerTarget;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 desirePos = playerTarget.position + offset;
        Vector3 newPosition = Vector3.Lerp(transform.position, desirePos, smoothVelocity);
        transform.position = newPosition;
    }
}
