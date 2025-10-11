using UnityEngine;

public class DestroyDeath : Death
{
    public override void Die()
    {
        Destroy(gameObject);
    }
}
