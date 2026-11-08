using UnityEngine;

public class spiralBltSpwaner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bulletPrefab;
    public float spawnCd = 0.05f;
    public float angleStep = 10f;
    private float timer;
    private float angle;
    void Start()
    {
        
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnCd)
        {
            timer -= spawnCd;
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        GameObject newBullet = Instantiate(
            bulletPrefab,
            transform.position,
            Quaternion.identity
        );

        Vector2 direction = new Vector2(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad)
        );

        newBullet.GetComponent<spiralBlt>().SetDirection(direction);

        angle += angleStep;
    }
}
