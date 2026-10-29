using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("boundary"))
        {
            Debug.Log("collided");
            Destroy(gameObject);
        }
    }
}
