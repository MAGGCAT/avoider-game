using UnityEngine;
using TMPro;

public class RecordTimer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text timerText;
    private float timer;
    private bool isRunning = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("F2") + "s";
        }
    }
    public void StopTimer()
    {
        isRunning = false;
    }
}
