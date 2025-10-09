using UnityEngine;

public abstract class Death : MonoBehaviour
{

    public virtual void Die()
    {
        Debug.Log("It's... over?");
    }
}
