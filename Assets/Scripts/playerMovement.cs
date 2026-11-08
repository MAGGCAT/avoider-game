using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float speed = 5;
    public float focusSpeed = 1;
    private float currentSpeed;
    public Sprite focusSprite;
    private Rigidbody2D rb;
    private Collider2D collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Timer
    void Update()
    {

    }
    // Player Death
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemies")){
            gameObject.SetActive(false);
            Debug.Log("u die");
        }
    }
    // Player Movement
    void OnMove(InputValue value)
    {
        rb.linearVelocity = value.Get<Vector2>() * currentSpeed; 
    }
    void OnShift(InputValue value)
    {
        if (value.isPressed)
        {
            currentSpeed = focusSpeed;
        }
        else
        {
            currentSpeed = speed;
        }
    }
}
