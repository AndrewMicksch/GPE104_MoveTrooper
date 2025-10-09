using UnityEngine;

public class DamageOnEnter : MonoBehaviour
{
    public bool isInstantKill;
    public float damageDone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        HealthComp otherHealth = other.gameObject.GetComponent<HealthComp>();
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(damageDone);
        }
    }
}
