using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float spawnCooldown = 2;
    public float minPosition;
    public float maxPosition;
    public float minEnemySpeed;
    public float maxEnemySpeed;
    public float speedUpSpeed;
    public float speedUpCd;
    private float speedUpTimer;
    private bool speedUp;
    public GameObject[] enemyObjects;
    private float timer;
    void Start()
    {
        timer = 0;
        speedUpTimer = 0;
        speedUp = false;
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
        speedUpTimer += Time.deltaTime;
        if (speedUpTimer >= speedUpCd)
        {
            speedUpTimer = 0;
            speedUp = true;
        }
    }
    void SpawnEnemy()
    {
        Vector3 randomPosition = transform.position;
        randomPosition.y = Random.Range(minPosition, maxPosition);
        // get random enemy prefab from list
        int targetEnemyIndex = Random.Range(0, enemyObjects.Length);
        GameObject enemyPrefab = enemyObjects[targetEnemyIndex];

        GameObject enemy = Object.Instantiate(enemyPrefab, randomPosition, transform.rotation);

        float randomSpeed = Random.Range(minEnemySpeed, maxEnemySpeed);
        if (speedUp == true)
        {
            randomSpeed += speedUpSpeed;
        }
        enemyMovement enemyMovement = enemy.GetComponent<enemyMovement>();
        enemyMovement.speed = randomSpeed;
    }
}
