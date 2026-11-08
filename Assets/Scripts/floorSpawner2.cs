using UnityEngine;

public class floorSpawner2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float spawnCd;
    public GameObject floor;
    public int numRow;
    public int numColumn;
    public float yOffset;
    private float timer;
    private float[] xPos;
    private float[] yPos;
    private float pRange = 33.3333f;
    void Start()
    {
        FillPosArray();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnCd)
        {
            timer = 0;
            SpawnRandomFloor();
        }
    }
    void SpawnFloor(int xIndex, int yIndex)
    {
        Vector3 floorPos = new Vector3(xPos[xIndex], yPos[yIndex], 0);
        GameObject newfloor = Object.Instantiate(floor, floorPos, transform.rotation);
    }
    void FillPosArray()
    {
        SpriteRenderer floorSprite = floor.GetComponent<SpriteRenderer>();
        Vector2 floorSize = floorSprite.bounds.size;

        xPos = new float[numRow];
        yPos = new float[numColumn];

        for (int i = 0; i < numRow; i++)
        {
            xPos[i] = (i + 0.5f - numRow / 2f) * floorSize.x;
        }
        for (int i = 0; i < numColumn; i++)
        {
            yPos[i] = (i + 0.5f - numColumn / 2f) * floorSize.y + yOffset;
        }
    }
    void SpawnRandomFloor()
    {
        for (int i = 0; i < numRow; i++)
        {
            int currentRow = i;
            for (int a = 0; a < numColumn; a++)
            {
                float randomNum = Random.Range(0, 100);
                if (randomNum < pRange)
                {
                    SpawnFloor(currentRow, a);
                }
            }
        }
    }
}
