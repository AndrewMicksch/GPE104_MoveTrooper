using UnityEngine;

public class HealthComp : MonoBehaviour
{
    public float currentHP;
    public float maxHP;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float amount)
        {
        currentHP = currentHP - amount;
        if (!IsAlive() )
        {
            currentHP = 0;
            Die();
        }
    }
    public void Heal(float amount)
    {
        currentHP = currentHP + amount;
        if (currentHP > maxHP)
        {
                currentHP = maxHP;
        }
    }

    //TODO handle death in health component
    public void Die()
        {
        
        }

    public bool IsAlive()
    { 
        if (currentHP > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   
}
