using UnityEngine;

public class swordSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject swordPrefab;
    public float spawnCd;
    public float xOffset;
    public float yOffset;
    public float xCenterOffset;
    public float yCenterTopOffset;
    public float yCenterBottomOffset;
    private float timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnCd)
        {
            timer = 0;
            SpawnSword();
        }
    }
    void SpawnSword()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnPos;
        Vector2 direction;

        //top
        if (side == 0)
        {
            spawnPos = new Vector2(Random.Range(-xCenterOffset, xCenterOffset), yOffset);
            direction = Vector2.down;
        }
        //bottom
        else if (side == 1) 
        {
            spawnPos = new Vector2(Random.Range(-xCenterOffset, xCenterOffset), -yOffset);
            direction = Vector2.up;
        }
        //left
        else if (side == 2)
        {
            spawnPos = new Vector2(-xOffset, Random.Range(yCenterBottomOffset, yCenterTopOffset));
            direction = Vector2.right;
        }
        //right
        else
        {
            spawnPos = new Vector2(xOffset, Random.Range(yCenterBottomOffset, yCenterTopOffset));
            direction = Vector2.left;
        }
        GameObject newSword = Instantiate(swordPrefab, spawnPos, Quaternion.identity);
        newSword.GetComponent<swordMovement>().SetDirection(direction);
    }
}
