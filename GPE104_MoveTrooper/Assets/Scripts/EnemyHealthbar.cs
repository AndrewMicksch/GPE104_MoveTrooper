using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public Image enemyHealthBar;
    public HealthComp enemy;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy = this.GetComponentInParent<HealthComp>();
        UpdateHealth();
    }

    void UpdateHealth()
    {
        enemyHealthBar.fillAmount = enemy.currentHP / enemy.maxHP;
    }
}
