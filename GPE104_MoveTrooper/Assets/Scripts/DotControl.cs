using UnityEngine;

public class DotControl : MonoBehaviour
{

    public Pawn dotter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad8))
        {
            //TODO: Tell Pawn to Move Forward
            dotter.MoveForward(dotter.moveSpeed);
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            //TODO: Tell Pawn to Move Forward
            dotter.MoveBackward(dotter.moveSpeed);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            //TODO: Tell Pawn to Move Forward
            dotter.RotateClockwise(dotter.turnSpeed);
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            //TODO: Tell dotter to Move Forward
            dotter.RotateCounterClockwise(dotter.turnSpeed);
        }
    }
}
