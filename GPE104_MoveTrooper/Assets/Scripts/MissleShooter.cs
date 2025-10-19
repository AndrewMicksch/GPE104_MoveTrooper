using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MissleShooter : BulletClass
{
    public float damageDone;
    public float effectArea;
    public float explosionLength;
    public bool destroyOnHit;
    public Collider2D hitbox;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitbox = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Bullet()
    {
        
    }
    public void Explode(float explosionLength)
    {
        StartCoroutine(DestroySelf());
    }
    //TODO: add a new sprite for shielding.
    private IEnumerator DestroySelf()
    {
        if (hitbox != null)
        {
            
            yield return new WaitForSeconds(explosionLength);

            GameObject.Destroy(gameObject);

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
    transform.localScale = new Vector3(1, 1, 0) * effectArea;
        HealthComp otherHealth = other.gameObject.GetComponent<HealthComp>();
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(damageDone);
        }

        if (destroyOnHit)
        {
            Death otherDeath = other.gameObject.GetComponent<Death>();
            if (otherDeath != null)
            {
                Explode(explosionLength);
            }

        }
    }
}
