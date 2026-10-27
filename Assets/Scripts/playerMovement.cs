using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 1;
    private Vector2 moveInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveInput * speed * Time.deltaTime);
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
