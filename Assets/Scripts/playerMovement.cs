using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float speed = 5;
    public float focusSpeed = 1;
    private float currentSpeed;
    public Sprite sprite;
    public Sprite focusSprite;
    public float focusRadius = 0.2f;
    public RecordTimer recordTimer;
    private float normalRadius;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private CircleCollider2D collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalRadius = collider.radius;
    }

    // Timer
    void Update()
    {

    }
    // Player Death
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemies")){
            recordTimer.StopTimer();
            gameObject.SetActive(false);
            //Debug.Log("u die");
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
            spriteRenderer.sprite = focusSprite;
            collider.radius = focusRadius;
        }
        else
        {
            currentSpeed = speed;
            spriteRenderer.sprite = sprite;
            collider.radius = normalRadius;
        }
    }
}
