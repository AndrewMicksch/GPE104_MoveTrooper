using UnityEngine;
using UnityEngine.UIElements;

public class BulletShooter : BulletClass
{
    public float damageDone;
    public bool destroyOnHit;
    private AudioSource firingSFX;
    public float shootSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firingSFX = this.GetComponent<AudioSource>();
        firingSFX.PlayOneShot(GameManager.core.shootSFX);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot(shootSpeed);
        OutofBounds();
    }
    public override void Bullet()
    {
       
    }
    void OutofBounds()
    {
        if ((transform.position.x >= GameManager.core.maxX) || (transform.position.y >= GameManager.core.maxY) || (transform.position.x <= GameManager.core.minX) || (transform.position.y <= GameManager.core.minY))
        {
            Destroy(gameObject);
        }
    }
    void Shoot(float shootSpeed)
    {
        transform.position = transform.position + (transform.up * shootSpeed) * Time.deltaTime;
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
