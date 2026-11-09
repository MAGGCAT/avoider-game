using UnityEngine;

public class spiralBltSpwaner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bulletPrefab;
    public float spawnCd = 0.05f;
    public float angleStep = 10f;
    public float xPosRange;
    public float yPosRange;
    public float moveCd;
    public float moveSpeed;
    public float slowSpeed;
    private float speed;
    private float moveTimer;
    private Vector2 targetPosition;

    private float timer;
    private float angle;

    public float startDelay = 4f;
    private bool isStarted = false;
    void Start()
    {
        targetPosition = new Vector2(0, 0);
        speed = slowSpeed;
    }
    void Update()
    {

        if (!isStarted)
        {
            startDelay -= Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (startDelay <= 0)
            {
                speed = moveSpeed;
                isStarted = true;
            }
            return;
        }

        //begin
        timer += Time.deltaTime;

        //Spawn Bullet
        if (timer >= spawnCd)
        {
            timer = 0;
            SpawnBullet();
        }

        //Move
        moveTimer += Time.deltaTime;
        if(moveTimer >= moveCd)
        {
            moveTimer = 0f;
            targetPosition = new Vector2(Random.Range(-xPosRange, xPosRange), Random.Range(-yPosRange, yPosRange));

        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    void SpawnBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        newBullet.GetComponent<spiralBlt>().SetDirection(direction);

        angle += angleStep;
    }
}
