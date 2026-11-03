using UnityEngine;

public class floor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite floor1;
    public Sprite floor2;
    public float interval;
    public Collider2D collider;
    private float timer;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider.enabled = false;
        spriteRenderer.sprite = floor1;
        //InvokeRepeating
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            spriteRenderer.sprite = floor2;
        } 
    }
}
