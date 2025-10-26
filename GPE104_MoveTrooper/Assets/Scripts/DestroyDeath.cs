using UnityEngine;

public class DestroyDeath : Death
{

    public bool player;
    public override void Die()
    {
        Destroy(gameObject);
    }
}
