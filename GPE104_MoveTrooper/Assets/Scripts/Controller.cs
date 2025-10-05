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
        //TODO Create the booster speed shifter
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("Booster Activated|Left/Right Shift down");
            pawn.moveSpeed = pawn.moveSpeed * pawn.booster;
        }
        //TODO make a way to reset to default speed after having boosted
        else if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            pawn.moveSpeed = pawn.baseSpeed;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("The T key is down");
            //Set the locations it can teleport to
            pawn.shipBlink();
        }

        // Move the ship forward in local space
        if (Input.GetKey(KeyCode.W))
        {
            //TODO: Tell Pawn to Move Forward
            Debug.Log("W is key is Down");
            pawn.MoveForward(pawn.moveSpeed);
        }

        // move ship left
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A is key is Down");
            pawn.MoveLeft(pawn.moveSpeed);
        }

        //move ship right
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D is key is Down");
            pawn.MoveRight(pawn.moveSpeed);
        }

        //move ship back
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S is key is Down");
            pawn.MoveBackward(pawn.moveSpeed);
        }



        //TODO move the ship in world space SHould move only one tiny bit at a time

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("LeftArrow is down");
            pawn.HorizontalLeft(pawn.moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("RightArrow is key is Down");
            pawn.HorizontalRight(pawn.moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("UpArrow is Down");
            pawn.VerticalUp(pawn.moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("DownArrow is down");
            pawn.VerticalDown(pawn.moveSpeed);
        }

        //rotates the ship left and right
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("E is held");
            pawn.RotateClockwise(pawn.turnSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Q is heald");
            pawn.RotateCounterClockwise(pawn.turnSpeed);
        }

        
        
    }
}
