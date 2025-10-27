using Unity.VisualScripting;
using UnityEngine;

public class DestroyDeath : Death
{

    public bool Point;
    public override void Die()
    {
        Destroy(gameObject);
        if (Point == true)
        {
            GameManager.core.Score += 1;
        }
    }
}
