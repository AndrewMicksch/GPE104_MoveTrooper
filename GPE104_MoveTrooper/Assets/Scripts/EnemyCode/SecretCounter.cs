using UnityEngine;

public class SecretCounter : MonoBehaviour
{
    public bool isActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.core.secret.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        if( GameManager.core.Score >= 100 && isActive != true)
        {
            isActive = true;
            GameManager.core.SecretSpawn();
        }
    }
    //void OnDestroy()
    //{
    //    GameManager.core.secret.Remove(this);

    //    if (GameManager.core.secret != null)
    //    {
    //        if(GameManager.core.secret.Count <= 0)
    //        {
    //            GameManager.core.SecretSpawn();
    //        }
    //    }
    //}
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    Death otherDeath = other.gameObject.GetComponent<Death>();
    //    HealthComp otherHealth = other.gameObject.GetComponent<HealthComp>();

    //    if ((otherHealth != null) || (otherDeath != null))
    //    {

    //        GameObject.Destroy(gameObject);
    //    }
    //}

}
