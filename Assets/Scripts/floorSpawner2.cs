using UnityEngine;

public class floorSpawner2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float spawnCd;
    public GameObject floor;
    public int numRow;
    public int numColumn;
    private float timer;
    private float[] xPos;
    private float[] yPos;
    void Start()
    {
        FillPosArray();
        for (int i = 0; i < numColumn; i++)
        {
            SpawnFloor(1, i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
            yPos[i] = (i + 0.5f - numColumn / 2f) * floorSize.y;
        }
    }
}
