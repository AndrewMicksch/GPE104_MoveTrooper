using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Pawn asteroid;
    public Pawn uFO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (uFO != null || asteroid != null)
        {
            MakeDecisions();
        }
    }
    private void MakeDecisions()
    {

    }
}
