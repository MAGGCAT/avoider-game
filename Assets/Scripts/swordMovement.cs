using UnityEngine;
using System.Collections;

public class swordMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5f;
    public float pauseTime = 1f;
    public float stopDisX = 2f;
    public float stopDisYTop = 2f;
    public float stopDisYBottom = 2f;
    private Vector2 direction;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;

        // set rotation
        if (direction == Vector2.down)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        else if (direction == Vector2.up)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (direction == Vector2.left)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        StartCoroutine(MoveSword());
    }

    IEnumerator MoveSword()
    {
        // 进入屏幕并移动到停止位置
        while (!ReachedStopPosition())
        {
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
            yield return null;
        }
        // 停顿
        yield return new WaitForSeconds(pauseTime);

        // 继续横穿屏幕
        while (true)
        {
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
            yield return null;
        }
    }

    bool ReachedStopPosition()
    {
        if (direction == Vector2.down)
            return transform.position.y <= stopDisYTop;

        if (direction == Vector2.up)
            return transform.position.y >= stopDisYBottom;

        if (direction == Vector2.right)
            return transform.position.x >= -stopDisX;

        return transform.position.x <= stopDisX;
    }
}
