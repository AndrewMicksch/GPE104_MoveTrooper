using UnityEngine;

public class Pawn : MonoBehaviour
{
    public float baseSpeed;
    public float moveSpeed;
    public float booster;
    public float turnSpeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    

    public void MoveForward(float moveSpeed)
    {
        // Change pawns position | In forward direction, Magnitude of movespeed
        transform.position = transform.position + (transform.up * moveSpeed) * Time.deltaTime;

    }

    public void MoveBackward(float moveSpeed)
    {

        transform.position = transform.position + (-transform.up * moveSpeed) * Time.deltaTime;
    }

    public void MoveLeft(float moveSpeed)
    {
        transform.position = transform.position + (-transform.right * moveSpeed) * Time.deltaTime;
    }

    public void MoveRight(float moveSpeed)
    {
        transform.position = transform.position + (transform.right * moveSpeed) * Time.deltaTime;
    }


    public void RotateCounterClockwise(float rotateValue)
    {
        transform.Rotate( 0.0f, 0.0f, rotateValue * Time.deltaTime);
    }
    public void RotateClockwise(float rotateValue)
    {
        transform.Rotate(0.0f, 0.0f, -rotateValue * Time.deltaTime);
    }


    public void HorizontalLeft(float moveSpeed)
    {
        transform.position = transform.position + (-Vector3.right * moveSpeed) * Time.deltaTime;
    }

    public void HorizontalRight(float moveSpeed)
    {
        transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
    }

    public void VerticalUp(float moveSpeed)
    {
        transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;
    }

    public void VerticalDown(float moveSpeed)
    {
        transform.position = transform.position + (-Vector3.up * moveSpeed) * Time.deltaTime;
    }


   
}
