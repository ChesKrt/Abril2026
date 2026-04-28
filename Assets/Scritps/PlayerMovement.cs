using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    private float _startSpeed;

    private CharacterController _cc;
    private float _gravity = -9.81f;
    [SerializeField] private float _jumpHeight = 1.5f;

    private bool _isGrounded;
    private float _veticalVelocity;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _startSpeed = _speed;
    }

    void Update()
    {
        Vector3 moveDir = Vector3.forward * _speed;

        _isGrounded = _cc.isGrounded;

        if (_isGrounded == true)
        {
            _veticalVelocity = -2f;
        }

        if (_isGrounded == true && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _veticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        moveDir.y = _veticalVelocity;

        _veticalVelocity += _gravity * Time.deltaTime;

        _cc.Move(moveDir * Time.deltaTime);
    }

    public void StopMovement()
    {
        _speed = 0;
    }

    public void StartMovement()
    {
        _speed = _startSpeed;
    }

}
