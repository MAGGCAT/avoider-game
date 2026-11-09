using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text highRecordText;
    void Start()
    {
        float highRecord = PlayerPrefs.GetFloat("HighRecord", 0);
        highRecordText.text = "Highest Record : " + highRecord.ToString("F2") + "s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
