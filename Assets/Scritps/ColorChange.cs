using UnityEngine;
using UnityEngine.InputSystem;

public class ColorChange : MonoBehaviour
{
    public Color[] colors;
    public Material material;

    public bool isInvisible;

    public float maxTime = 3f;
    private float _currentTime = 0;
    private bool _startTimer = false;

    void Start()
    {
        material.color = colors[0];
    }

    void Update()
    {
        if (Keyboard.current != null)
        {
            if (Keyboard.current.fKey.wasPressedThisFrame)
            {
                ChangeColor();
            }
        }

        if (Gamepad.current != null)
        {
            if (Gamepad.current.buttonNorth.wasPressedThisFrame)
            {
                ChangeColor();
            }
        }

        if (_startTimer == true)
        {
            InvisibleTimer();
        }

    }

    private void ChangeColor()
    {
        if (isInvisible == false)
        {
            material.color = colors[1];
            _startTimer = true;
            isInvisible = true;
        }
        else
        {
            material.color = colors[0];
            _startTimer = false;
            _currentTime = 0;
            isInvisible = false;
        }

    }

    private void InvisibleTimer()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > maxTime)
        {
            material.color = colors[0];
            _startTimer = false;
            _currentTime = 0;
            isInvisible = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Obstacle>(out Obstacle obstacle))
        {
            if (isInvisible == false)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

}
