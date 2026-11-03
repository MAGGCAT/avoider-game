using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LaserSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float spawnCD;
    public float minXPos;
    public float maxXPos;
    public float minYPos;
    public float maxYPos;
    public GameObject laserVerticalPrefab;
    public GameObject laserHorizontalPrefab;
    private float timer;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnCD)
        {
            timer = 0;
            Vector3 randomXPos = new(Random.Range(minXPos, maxXPos), transform.position.y, transform.position.z);
            Vector3 randomYPos = new(transform.position.x, Random.Range(minYPos, maxYPos), transform.position.z);
            SpawnLaser(randomXPos, laserVerticalPrefab, 0);
            SpawnLaser(randomYPos, laserHorizontalPrefab, 90);
        }
    }
    void SpawnLaser(Vector3 randomPos, GameObject cd1, float angle)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        GameObject newlaser = Object.Instantiate(cd1, randomPos, rotation);
    }

}
