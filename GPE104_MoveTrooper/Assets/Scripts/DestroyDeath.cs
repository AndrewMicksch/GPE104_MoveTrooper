using Unity.VisualScripting;
using UnityEngine;

public class DestroyDeath : Death
{

    public bool point;
    public bool isHIM;
    public float pointAmount;
    private AudioClip deathSFX;

    void Start()
    {

    }
    public override void Die()
    {

        Destroy(gameObject);
        if (point == true)
        {
            GameManager.core.Score += (int)(1 * pointAmount);
        }
        if (isHIM == true)
        {
            GameManager.core.winCondition = true;
        }
    }
}
