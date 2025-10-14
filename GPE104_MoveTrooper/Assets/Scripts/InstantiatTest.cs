using UnityEngine;

public class InstantiatTest : MonoBehaviour
{

    public GameObject prefabToCopy;
    public Controller controllerToConnect;
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
            }
          
        }   
    }
}
