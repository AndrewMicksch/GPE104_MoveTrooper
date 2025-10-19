using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Pawn pawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pawn != null)
        {
            MakeDecisions();
        }
    }
    private void MakeDecisions()
    {
        //TODO Create the booster speed shifter
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            pawn.moveSpeed = pawn.moveSpeed * pawn.booster;
        }
        //TODO make a way to reset to default speed after having boosted
        else if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            pawn.moveSpeed = pawn.baseSpeed;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            //Set the locations it can teleport to
            pawn.shipBlink();
        }

        // Move the ship forward in local space
        if (Input.GetKey(KeyCode.W))
        {
            //TODO: Tell Pawn to Move Forward
            pawn.MoveForward(pawn.moveSpeed);
        }

        // move ship left
        if (Input.GetKey(KeyCode.Q))
        {
            pawn.MoveLeft(pawn.moveSpeed);
        }

        //move ship right
        if (Input.GetKey(KeyCode.E))
        {
            pawn.MoveRight(pawn.moveSpeed);
        }

        //move ship back
        if (Input.GetKey(KeyCode.S))
        {
            pawn.MoveBackward(pawn.moveSpeed);
        }



        //TODO move the ship in world space SHould move only one tiny bit at a time

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pawn.HorizontalLeft(pawn.moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pawn.HorizontalRight(pawn.moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pawn.VerticalUp(pawn.moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pawn.VerticalDown(pawn.moveSpeed);
        }

        //rotates the ship left and right
        if (Input.GetKey(KeyCode.D))
        {
            pawn.RotateClockwise(pawn.turnSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            pawn.RotateCounterClockwise(pawn.turnSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pawn.ShieldMode(pawn.iFrameDuration);
            Debug.Log("Space is pressed");
        } 

        
        
    }
}
