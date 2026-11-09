using UnityEngine.SceneManagement;
using UnityEngine;

public class LaserCD1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite cd1;
    public Sprite cd2;
    public Sprite laser;
    public float interval1 = 0.3f;
    public float interval2 = 0.5f;
    public float disappearAfter = 0.6f;
    public Collider2D laserCollider;
    private float timer;
    private int stage = 0;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        laserCollider.enabled = false;
        spriteRenderer.sprite = cd1;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (stage == 0 && timer >= interval1)
        {
            spriteRenderer.sprite = cd2;
            stage = 1;
        }

        else if (stage == 1 && timer >= interval2)
        {
            spriteRenderer.sprite = laser;
            laserCollider.enabled = true;
            stage = 2;
        }

        else if (stage == 2 && timer >= disappearAfter)
        {
            Destroy(gameObject);
        }
    }
}
