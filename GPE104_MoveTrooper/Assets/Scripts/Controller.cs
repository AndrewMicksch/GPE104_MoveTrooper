using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Pawn player;
    public Pawn bull;

    [Header("spawner")]
    public GameObject prefabToCopy;
    public Controller controllerToConnect;
    public GameObject prefabBullet1;
    public GameObject prefabBullet2;
    public Controller bulletControlToConnect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //spawn the initial pawn
        if (player == null)
        {
            GameObject tempPawn;
            tempPawn = Instantiate(prefabToCopy, Vector3.zero, Quaternion.identity) as GameObject;

            if (tempPawn != null)
            {
                Pawn pawnComponent = tempPawn.GetComponent<Pawn>();

                if (tempPawn != null)
                {
                    controllerToConnect.player = pawnComponent;
                }
            }
        }
        if (player != null)
        {
            MakeDecisions();




        }
    }
    private void MakeDecisions()
    {


        //Spawn the Pawn

       

                //TODO Create the booster speed shifter
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
             player.moveSpeed = player.moveSpeed * player.booster;
        }


        //TODO make a way to reset to default speed after having boosted
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            player.moveSpeed = player.baseSpeed;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            //Set the locations it can teleport to
            player.shipBlink();
        }

        // Move the ship forward in local space
        if (Input.GetKey(KeyCode.W))
        {
            //TODO: Tell Pawn to Move Forward
            player.MoveForward(player.moveSpeed);
        }

        // move ship left
        if (Input.GetKey(KeyCode.Q))
        {
            player.MoveLeft(player.moveSpeed);
        }

        //move ship right
        if (Input.GetKey(KeyCode.E))
        {
            player.MoveRight(player.moveSpeed);
        }

        //move ship back
        if (Input.GetKey(KeyCode.S))
        {
            player.MoveBackward(player.moveSpeed);
        }



        //TODO move the ship in world space SHould move only one tiny bit at a time

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.HorizontalLeft(player.moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.HorizontalRight(player.moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.VerticalUp(player.moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.VerticalDown(player.moveSpeed);
        }

        //rotates the ship left and right
        if (Input.GetKey(KeyCode.D))
        {
            player.RotateClockwise(player.turnSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.RotateCounterClockwise(player.turnSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.ShieldMode(player.iFrameDuration);
            Debug.Log("Space is pressed");
        }

        //Bullet instructions


        if (Input.GetKeyDown(KeyCode.J))
        {
            //player.FireBullet1();

            GameObject tempBull;
            tempBull = Instantiate(prefabBullet1, player.transform.up, player.transform.rotation) as GameObject;
            if (tempBull != null)
            {
                Pawn bullComponent = tempBull.GetComponent<Pawn>();
                if (tempBull != null)
                {
                    bulletControlToConnect.bull = bullComponent;
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {

            GameObject tempBull;
            tempBull = Instantiate(prefabBullet2, player.transform.up, player.transform.rotation) as GameObject;
            if (tempBull != null)
            {
                Pawn bullComponent = tempBull.GetComponent<Pawn>();
                if (tempBull != null)
                {
                    bulletControlToConnect.bull = bullComponent;
                }

            }
        }


        if (bull != null)
        {

            bull.Shoot(bull.bulletSpeed + player.moveSpeed);
        }


    }

   
    
    
    
}
    

