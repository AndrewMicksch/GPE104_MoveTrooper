using UnityEngine;

public class BulletShooter : BulletClass
{
    public float damageDone;
    public bool destroyOnHit;
    private AudioSource firingSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firingSFX = this.GetComponent<AudioSource>();
        firingSFX.PlayOneShot(GameManager.core.shootSFX);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Bullet()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bump");
        HealthComp otherHealth = other.gameObject.GetComponent<HealthComp>();
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(damageDone);
        }

        if (destroyOnHit)
        {
            Death otherDeath = other.gameObject.GetComponent<Death>();
            if ((otherHealth != null) || (otherDeath != null))
            {
                GameObject.Destroy(gameObject);
            }

        }
    }
    
}
