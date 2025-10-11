using UnityEngine;

public class DeathTest : MonoBehaviour
{
    public Pawn testingPawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Code to test deaths. and heals
        if (Input.GetKeyDown(KeyCode.P))
        {
            testingPawn.death.Die();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("that sucked");
            testingPawn.health.TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("That feels better");
            testingPawn.health.Heal(1);
        }
    }
}
