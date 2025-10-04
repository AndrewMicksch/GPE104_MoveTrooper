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
        MakeDecisions();
    }
    private void MakeDecisions()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            pawn.moveSpeed = pawn.moveSpeed * pawn.booster;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            pawn.moveSpeed = pawn.baseSpeed;
        }



        // Move the ship forward in local space
        if (Input.GetKey(KeyCode.W))
        {
            //TODO: Tell Pawn to Move Forward
            pawn.MoveForward(pawn.moveSpeed);
        }

        // move ship left
        if (Input.GetKey(KeyCode.A))
        {
            pawn.MoveLeft(pawn.moveSpeed);
        }

        //move ship right
        if (Input.GetKey(KeyCode.D))
        {
            pawn.MoveRight(pawn.moveSpeed);
        }
        //move ship back
        if (Input.GetKey(KeyCode.S))
        {
            pawn.MoveBackward(pawn.moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pawn.HorizontalLeft(pawn.moveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pawn.HorizontalRight(pawn.moveSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pawn.VerticalUp(pawn.moveSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pawn.VerticalDown(pawn.moveSpeed);
        }

        //rotates the ship
        if (Input.GetKey(KeyCode.E))
        {
            pawn.RotateClockwise(pawn.turnSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            pawn.RotateCounterClockwise(pawn.turnSpeed);
        }

        //Move ship at double Speed
        
    }
}
