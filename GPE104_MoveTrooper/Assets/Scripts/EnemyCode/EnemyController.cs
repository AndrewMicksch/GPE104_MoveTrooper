using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Pawns")]
    public Pawn asteroid;
    public Pawn uFO;
    public Pawn baby;
    public Pawn him;

    [Header("targets")]
    public Controller playerTarg;
    public GameObject pawnToMoveTowards;
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
        if (uFO != null || him != null)
        {
            playerTarg.GetComponent<Pawn>();
            pawnToMoveTowards = playerTarg.player.gameObject;
            uFO.MoveTowards(pawnToMoveTowards.gameObject.transform.position);
            him.MoveTowards(pawnToMoveTowards.gameObject.transform.position);
        }
        if (asteroid != null || baby != null)
        {
            asteroid.MoveTowards(asteroid.pointToMoveTowards);
            baby.MoveTowards(baby.pointToMoveTowards);
        }
    }
}
