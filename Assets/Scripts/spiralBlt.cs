using UnityEngine;

public class spiralBlt : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 4f;
    private Vector2 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(direction * speed * bulletSpeedManage.multiplier * Time.deltaTime);
    }
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("boundary"))
        {
            Destroy(gameObject);
        }
    }
}
