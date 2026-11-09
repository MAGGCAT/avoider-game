using UnityEngine;

public class lightSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject lightPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnLight()
    {
        GameObject newBullet = Instantiate(lightPrefab, transform.position, transform.rotation);
    }
}
