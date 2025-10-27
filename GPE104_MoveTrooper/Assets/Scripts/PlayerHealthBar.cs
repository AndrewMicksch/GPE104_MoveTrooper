using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image PlayerHealth;
    public HealthComp player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        player = this.GetComponentInParent<HealthComp>();
        UpdateHealth();
    }

    void UpdateHealth()
    {
        PlayerHealth.fillAmount = player.currentHP / player.maxHP;
    }
}
