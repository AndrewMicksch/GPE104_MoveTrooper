using Unity.VisualScripting;
using UnityEngine;

public class DestroyDeath : Death
{

    public bool Point;
    private AudioClip deathSFX;

    void Start()
    {
        deathSFX = GameManager.core.deathSFX;
    }
    public override void Die()
    {
        AudioSource.PlayClipAtPoint(deathSFX, transform.position, 1.0f);
        Destroy(gameObject);
        if (Point == true)
        {
            GameManager.core.Score += 1;
        }
        

    }
}
