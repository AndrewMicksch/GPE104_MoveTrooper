using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

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
    public float iFrameDuration;


    [Header("Components")]
    public HealthComp health;
    public Death death;
    public Collider2D hitbox;
    

    //add a location for bullets to spawn and a speed.
    public float bulletSpeed;
    //public float bulletSpawn;
    //public GameObject bulletShot;




    // Start is called before the first frame update
    void Start()
    {
        //load health and death component
        health = GetComponent<HealthComp>();
        death = GetComponent<Death>();
        hitbox = GetComponent<Collider2D>();
    }



    // Update is called once per frame
    void Update()
    {

    }

    // TODO use these for future pawns.
    public void MoveTowards(Vector3 pointToMoveTowards)
    {
        //find vecotor towards that point
        Vector3 moveVector = pointToMoveTowards - transform.position;
        //normalize
        moveVector.Normalize();
        //multiply
        moveVector *= moveSpeed * Time.deltaTime;
        //move that vector form my current position
        transform.position = transform.position + moveVector;
    }
    public void MoveTowards(GameObject objectToMoveTowards)
    {
        MoveTowards(objectToMoveTowards.transform);
    }
    public void MoveTowards(Transform transformToMoveTowards)
    {

    }

    public void MoveTowards(Controller controllerToMoveTowards)
    {
        MoveTowards(controllerToMoveTowards.pawn);
    }
    public void MoveTowards(Pawn pawnToMoveTowards)
    {
        MoveTowards(pawnToMoveTowards.gameObject);
    }

    //Invincibility
    public void ShieldMode(float iFrameDuration)
    {
        StartCoroutine(TempDisableHitbox());
    }
    //TODO: add a new sprite for shielding.
    private IEnumerator TempDisableHitbox()
    {
        if (hitbox != null)
        {
            hitbox.enabled = false;
            Debug.Log("Disabled hitbox");

            yield return new WaitForSeconds(iFrameDuration);

            hitbox.enabled = true;
            Debug.Log("renabled hitbox");

        }
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

    //introduce a bullet movement
    public void Shoot(float bulletSpeed)
    {
        transform.position = transform.position + (transform.up * bulletSpeed) * Time.deltaTime;
    }
    //public void SpawnBullet(float bulletSpawn)
    //{
    //    transform.position = transform.postition + (transform.up + bulletSpawn) * Time.deltaTime;
    //    GameObject tempBull;
    //    tempBull = Instantiate(bulletShot, bulletSpawn.transform.position, Quaternion.identity) as GameObject;
    //}


}
