using UnityEngine;

public class rainSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float spawnCooldown = 2;
    public float minPos;
    public float maxPos;
    public float minSpeed;
    public float maxSpeed;
    public GameObject[] rainPrefab;

    public float endAt;
    private float timer;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnCooldown)
        {
            timer = 0;
            SpawnEnemy();
        }
        endAt -= Time.deltaTime;
        if ( endAt <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    void SpawnEnemy()
    {
        Vector3 randomPosition = transform.position;
        randomPosition.x = Random.Range(minPos, maxPos);

        int targetEnemyIndex = Random.Range(0, rainPrefab.Length);
        GameObject currentPrefab = rainPrefab[targetEnemyIndex];

        GameObject newRain = Object.Instantiate(currentPrefab, randomPosition, Quaternion.Euler(0, 0, 90));

        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        rainMovement rainMovement = newRain.GetComponent<rainMovement>();
        rainMovement.speed = randomSpeed;
    }
}
