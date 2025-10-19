using UnityEditor.Rendering;
using UnityEngine;

public class InstantiatTest : MonoBehaviour
{

    public GameObject prefabToCopy;
    public Controller controllerToConnect;
    public GameObject prefabBullet;
    public Controller bulletControlToConnect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameObject tempPawn;
            tempPawn =  Instantiate(prefabToCopy, Vector3.zero, Quaternion.identity) as GameObject;

            if (tempPawn != null)
            {
                Pawn pawnComponent = tempPawn.GetComponent<Pawn>();

                if (tempPawn != null)
                {
                    controllerToConnect.pawn = pawnComponent;
                }

                //start of Bullet Code
                //TODO fix code
                if (Input.GetKeyDown(KeyCode.J))
                {
                    GameObject tempBull;
                    tempBull = Instantiate(prefabBullet, tempPawn.transform.up, tempPawn.transform.rotation) as GameObject;
                    if( tempBull != null)
                    {
                        Pawn bullComponent = tempBull.GetComponent<Pawn>();
                        if (tempBull != null)
                        {
                            bulletControlToConnect.pawn = bullComponent;
                        }
                        
                    }
                }

            }
           
          
        }  
        
        //new if for spawning a bullet
        
    }

    
}
