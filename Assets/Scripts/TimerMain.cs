using UnityEngine;

public class TimerMain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float timer = 0;
    public float cooldown = 10;
    public GameObject[] allSpawner;
    private int index;
    void Start()
    {
        index = 0;
        Switch();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            timer = 0;
            index += 1;
            Switch();
        }
    }
    void Switch()
    {
        if (allSpawner[index-1]  != null)
        {
            allSpawner[index - 1].SetActive(false);
        }
        if (index >= allSpawner.Length)
        {
            index = 0;
        }
        allSpawner[index].SetActive(true);
    }
    void Shuffle(GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = Random.Range(i, array.Length);
            GameObject temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
