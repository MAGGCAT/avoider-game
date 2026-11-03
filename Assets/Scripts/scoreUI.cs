using UnityEngine;
using TMPro;

public class scoreUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int score;
    private TMP_Text text;
    void Start()
    {
        score = 0;
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTreatPickup()
    {

    }
}
