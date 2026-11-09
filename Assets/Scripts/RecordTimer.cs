using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordTimer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text timerText;
    public TMP_Text currentRecordText;
    public TMP_Text highRecordText;
    public GameObject pausePanel;
    private float timer;
    private bool isRunning = true;
    void Start()
    {
        pausePanel.SetActive(false);
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
        if (!isRunning) return;
        isRunning = false;
        float highRecord = PlayerPrefs.GetFloat("HighRecord", 0f);

        if (timer > highRecord)
        {
            highRecord = timer;
            PlayerPrefs.SetFloat("HighRecord", timer);
            PlayerPrefs.Save();
        }

        currentRecordText.text = timer.ToString("F2") + "s";
        highRecordText.text = "Highest Record : " + highRecord.ToString("F2") + "s";

        pausePanel.SetActive(true);
    }
    void OnRKey()
    {
        if (isRunning == false)
        {
            RestartGame();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
