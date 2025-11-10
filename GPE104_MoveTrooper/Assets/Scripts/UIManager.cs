using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Image timeImage;
    public TMP_Text bottomText;
    public Image healthBar;
    public Image enemyHealthBar;
    public HealthComp player;
    public TMP_Text Score;
    public TMP_Text Lives;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.core.ResetTimer();
        bottomText.text = "Bottom Text";
        GameManager.core.ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        UpdateScore();
        UpdateLives();
    }

    void UpdateTimer()
    {
        GameManager.core.timeRemaining -= Time.deltaTime;
        timeImage.fillAmount = GameManager.core.timeRemaining / GameManager.core.maxTime;
        float displayTimeRemaining = (Mathf.Round(GameManager.core.timeRemaining * 100)) /100;
        bottomText.text = "Time Remaining:" + displayTimeRemaining;
    }
    void UpdateLives()
    {
        float displayLives = (Mathf.Round(GameManager.core.Lives));
        Lives.text = "lives:" + displayLives;
    }
    void UpdateScore()
    { 
        float displayScore = (Mathf.Round(GameManager.core.Score));
        Score.text = "Score:" + displayScore;
    }
    void UpdateHealth()
    {
        //if (player == true)
        //{
        //    healthBar.fillAmount = player.currentHP / player.maxHP;
        //}
    }
}
