using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Image timeImage;
    public TMP_Text bottomText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.core.ResetTimer();
        bottomText.text = "Bottom Text";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        
    }

    void UpdateTimer()
    {
        GameManager.core.timeRemaining -= Time.deltaTime;
        timeImage.fillAmount = GameManager.core.timeRemaining / GameManager.core.maxTime;
        bottomText.text = "Time Remaining: + GameManager.core.timeRemaining";
    }
}
