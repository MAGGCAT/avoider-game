using TMPro;
using UnityEngine;

public class Light : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float yMin;
    public float yMax;
    public float xRange;
    public float speed;
    public float yInit;
    public lightSpawner spawner;
    private float yPos;
    private float xPos;
    private Vector2 targetPos;
    void Start()
    {
        xPos = Random.Range(-xRange, xRange);
        transform.position = new Vector3(xPos, yInit, transform.position.z);
        yPos = Random.Range(yMin, yMax);
        targetPos = new Vector2(xPos, yPos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawner != null)
            {
                spawner.SpawnLight();
            }
            else
            {
                Debug.Log("missing");
            }
            
            Destroy(gameObject);
        }
    }
}
