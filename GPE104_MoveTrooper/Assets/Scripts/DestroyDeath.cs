using Unity.VisualScripting;
using UnityEngine;

public class DestroyDeath : Death
{

    public bool Point;
    public AudioClip deathSFX;
    public override void Die()
    {
        AudioSource.PlayClipAtPoint(GameManager.core.deathSFX, transform.position, 1.0f);
        Destroy(gameObject);
        if (Point == true)
        {
            GameManager.core.Score += 1;
        }
        

    }
}
