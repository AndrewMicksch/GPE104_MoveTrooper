using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DamageOnEnter : MonoBehaviour
{
    public bool isInstantKill;
    public bool destroyMutual;
    public float damageDone;
    private AudioSource hum;
    private AudioSource crash;
    private AudioClip passiveHum;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.core.damageZones.Add(this);
        hum = this.GetComponent<AudioSource>();
        passiveHum = GameManager.core.passiveHum;
        hum.clip = passiveHum;
        hum.loop = true;
        hum.Play();
        crash = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnDestroy()
    {
        GameManager.core.damageZones.Remove(this);
        AudioSource.PlayClipAtPoint(GameManager.core.deathSFX, transform.position, 1.0f);
    }
    
    
    void OnTriggerEnter2D (Collider2D other)
    {
        
        //check if should kill.
        if (isInstantKill)
        {
            Death otherDeath = other.gameObject.GetComponent<Death>();
            if (otherDeath != null)
            {
                HealthComp otherHealth = other.gameObject.GetComponent<HealthComp>();
                if (otherHealth != null)
                {
                    crash.PlayOneShot(GameManager.core.collisionSFX);
                    if (otherHealth.player == true)
                    {
                        GameManager.core.LoseGame();
                        otherDeath.Die();
                    }
                }
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
                crash.PlayOneShot(GameManager.core.collisionSFX);
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

        




    }    
        
}
    

