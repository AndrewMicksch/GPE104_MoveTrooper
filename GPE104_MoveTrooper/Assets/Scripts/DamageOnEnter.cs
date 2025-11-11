using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DamageOnEnter : MonoBehaviour
{
    public bool isInstantKill;
    public bool destroyMutual;
    public bool isUFO;
    public bool isAsteroid;
    public bool isBaby;
    public float damageDone;
    public GameObject spawner;
    private AudioSource hum;
    private AudioSource crash;
    private AudioClip passiveHum;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = GameManager.core.hazardSpawn;
        GameManager.core.damageZones.Add(this);
        GetComponent<GameObject>();
        hum = this.GetComponent<AudioSource>();
        passiveHum = GameManager.core.passiveHum;
        hum.clip = passiveHum;
        hum.loop = true;
        hum.Play();
        crash = this.GetComponent<AudioSource>();
        if(isUFO != false)
        {
            GameManager.core.uFOsInPlay.Add(this);
        }
        if(isAsteroid != false && isBaby != false)
        {
            GameManager.core.asteroidsInPlay.Add(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnDestroy()
    {
        GameManager.core.damageZones.Remove(this);
        AudioSource.PlayClipAtPoint(GameManager.core.deathSFX, transform.position, 1.0f);
        if (isUFO != false)
        {
            GameManager.core.uFOsInPlay.Remove(this);
        }
        if (isAsteroid != false && isBaby != true)
        {
            SetLocation();
            GameManager.core.asteroidsInPlay.Remove(this);
            SpawnHazards.spawner.SpawnChildren();
        }
        if (isBaby != false)
        {
            GameManager.core.asteroidsInPlay.Remove(this);
        }
    }

    void SetLocation()
    {
        SpawnHazards.spawner.spawnBabyPos = new Vector3(this.transform.position.x, this.transform.position.y);
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        DamageOnEnter otherEnter = other.gameObject.GetComponent<DamageOnEnter>();
        //check if should kill.
        if (isInstantKill)
        {
            Death otherDeath = other.gameObject.GetComponent<Death>();
            if (otherDeath != null && isUFO == false)
            {
                HealthComp otherHealth = other.gameObject.GetComponent<HealthComp>();
                if (otherHealth != null && otherHealth.player == true)
                {
                    crash.PlayOneShot(GameManager.core.collisionSFX);
                    if (otherHealth.player == true && GameManager.core.Lives == 0)
                    {
                        GameManager.core.LoseGame();
                        otherDeath.Die();
                    }
                    else
                    {
                        GameManager.core.Lives -= 1;
                        otherDeath.Die();
                    }
                }
                otherDeath.Die();
            }

        }
        else if (otherEnter == false)
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
    

