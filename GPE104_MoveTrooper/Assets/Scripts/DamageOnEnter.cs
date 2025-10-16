using Unity.VisualScripting;
using UnityEngine;

public class DamageOnEnter : MonoBehaviour
{
    public bool isInstantKill;
    public bool destroyMutual;
    public float damageDone;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.core.damageZones.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter2D (Collider2D other)
    {
        //check if should kill.
        if (isInstantKill)
        {
            Death otherDeath = other.gameObject.GetComponent<Death>();
            if (otherDeath != null)
            {
                otherDeath.Die();
            }

        }
        else
        {
            //deal damage
            Debug.Log("bump");
            HealthComp otherHealth = other.gameObject.GetComponent<HealthComp>();
            if (otherHealth != null)
            {
                otherHealth.TakeDamage(damageDone);
            }
        }
        if (destroyMutual)
        {
            HealthComp otherHealth = other.gameObject.GetComponent<HealthComp>();
            Death otherDeath = other.gameObject.GetComponent<Death>();
            if ((otherHealth != null) || (otherDeath!= null))
            {
                GameObject.Destroy(gameObject);
            }
            
        }

        void OnDestroy()
        {
            GameManager.core.damageZones.Remove(this);
        }
    }    
        
}
    

