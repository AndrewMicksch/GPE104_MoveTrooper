using UnityEngine;

public class Pawn : MonoBehaviour
{
    float minX = -10f;
    float maxX = 10f;
    float minY = -5f;
    float maxY = 5f;

    [Header("Movement")]
    public float baseSpeed;
    public float moveSpeed;
    public float booster;
    public float turnSpeed;

    [Header("Components")]
    public HealthComp health;
    public Death death;

    // Start is called before the first frame update
    void Start()
    {
        //load health and death component
        health = GetComponent<HealthComp>();

        death = GetComponent<Death>();
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
        transform.Rotate(0.0f, 0.0f, rotateValue * Time.deltaTime);
    }
    public void RotateClockwise(float rotateValue)
    {
        transform.Rotate(0.0f, 0.0f, -rotateValue * Time.deltaTime);
    }

    //TODO set up the values for world space movement
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
    public void shipBlink()
        {
            //Set the locations it can teleport to
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        transform.position = new Vector2(randomX, randomY);
        }

}
