using UnityEngine;

public class floorSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float[] xPos;
    public float[] yPos;
    public float spawnCd;
    public GameObject floor;
    private float timer;
    private int[] index;
    private int indexIndex;
    void Start()
    {
        index = new int[] { 0, 1, 2, 3};
        indexIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnCd)
        {
            timer = 0;
            SpawnFloor();
        }
    }
    void SpawnFloor()
    {
        Vector3 floorPos = new Vector3(xPos[index[indexIndex]], yPos[index[indexIndex]], transform.rotation.z);
        GameObject newfloor = Object.Instantiate(floor, floorPos, transform.rotation);
        indexIndex++;
        if (indexIndex >= index.Length)
        {
            Shuffle(index);
            indexIndex = 0;
        }
    }
    void Shuffle(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = Random.Range(i, array.Length);
            int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
