using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.2f;
    public Vector3 direction = Vector3.forward;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}
