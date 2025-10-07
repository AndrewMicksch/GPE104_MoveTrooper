using JetBrains.Annotations;
using UnityEngine;

public class DeathRecenter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Die()
    {
        Destroy(gameObject);
    }
}
