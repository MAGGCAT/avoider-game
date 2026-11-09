using UnityEngine;
using System.Collections;

public class bulletSpeedManage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static float multiplier = 1f;
    public float normalTime = 5f;
    public float fastTime = 3f;
    public float fastMultiplier = 2f;
    public float transitionTime = 2f;
    public float startDelay;
    void Start()
    {
        StartCoroutine(SpeedCycle());
    }

    IEnumerator SpeedCycle()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            yield return StartCoroutine(ChangeSpeed(1f, fastMultiplier));
            yield return new WaitForSeconds(fastTime);

            yield return StartCoroutine(ChangeSpeed(fastMultiplier, 1f));
            yield return new WaitForSeconds(normalTime);
        }
    }

    IEnumerator ChangeSpeed(float startSpeed, float targetSpeed)
    {
        float timer = 0f;
        while (timer < transitionTime)
        {
            timer += Time.deltaTime;
            float t = timer / transitionTime;
            t = Mathf.SmoothStep(0f, 1f, t);

            multiplier = Mathf.Lerp(startSpeed, targetSpeed, t);
            yield return null;
        }
        multiplier = targetSpeed;
    }
}
