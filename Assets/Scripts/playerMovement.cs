using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Timer
    void Update()
    {

    }
    // Player Death
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemies")){
            //gameObject.SetActive(false);
            Debug.Log("u die");
        }
    }
    // Player Movement
    void OnMove(InputValue value)
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(value.Get<Vector2>() * speed, ForceMode2D.Impulse); 
    }
}
