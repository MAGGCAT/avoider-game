using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject cd1;
    public GameObject cd2;
    public float interval1 = 0.3f;
    public float interval2 = 0.5f;
    public float disappearAfter = 0.6f;
    private float timer = 0;
    
    void Start()
    {
        cd1.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval1 && timer < interval2)
        {
            Destroy(cd1);
            cd2.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (timer > interval2 && timer < disappearAfter)
        {
            Destroy(cd2);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (timer > disappearAfter)
        {
            Destroy(gameObject);
        }
    }
}
