using UnityEngine;

public class floor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite floor1;
    public Sprite floor2;
    public float interval;
    public float destoryCd;
    public Collider2D collider;
    private float timer;
    private SpriteRenderer spriteRenderer;
    private int stage;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider.enabled = false;
        spriteRenderer.sprite = floor1;
        stage = 0;
        //InvokeRepeating
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (stage == 0 && timer >= interval)
        {
            stage++;
            spriteRenderer.sprite = floor2;
        } else if (stage == 1 && timer >= destoryCd)
        {
            Destroy(gameObject);
        }
    }
}
