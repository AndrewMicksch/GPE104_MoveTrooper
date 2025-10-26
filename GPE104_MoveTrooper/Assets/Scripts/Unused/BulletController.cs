using UnityEngine;

public class BulletController : MonoBehaviour
{

    public Pawn bull;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MakeDecisions();
    }
    //make the bullet shoot if it exists. add ship move speed 
    private void MakeDecisions()
    {
        if (bull != null)
        {

            bull.Shoot(bull.bulletSpeed);
        }
    }
}
