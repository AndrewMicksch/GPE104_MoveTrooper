using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Pawn : MonoBehaviour
{

    private Transform spawnPosition;

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
    public GameObject bulletType1;
    public GameObject bulletType2;
    public GameObject spawnPoint;
    public Controller bulletControlToConnect;

    [Header("Audio")]
    private AudioSource hum;
    private AudioClip passiveHum;

    //add a location for bullets to spawn and a speed.
    public float bulletSpeed;

  




    // Start is called before the first frame update
    void Start()
    {
        //load health and death component
        health = GetComponent<HealthComp>();
        death = GetComponent<Death>();
        hitbox = GetComponent<Collider2D>();
        hum = this.GetComponent<AudioSource>();
        passiveHum = GameManager.core.passiveHum;
        hum.clip = passiveHum;
        hum.loop = true;
        hum.Play();
      
       
    }



    // Update is called once per frame
    void Update()
    {
        WrapX();
        WrapY();
    }

    // TODO use these for future pawns.

    public void WrapX()
    {
        if (transform.position.x > GameManager.core.maxX && transform.position.x != GameManager.core.minX)
        {
            transform.position = new Vector3(GameManager.core.minX, transform.position.y);
        }
        if (transform.position.x < GameManager.core.minX && transform.position.x != GameManager.core.maxX)
        {
            transform.position = new Vector3(GameManager.core.maxX, transform.position.y);
        }
    }
    public void WrapY()
    {
        if (transform.position.y > GameManager.core.maxY && transform.position.y != GameManager.core.minY)
        {
            transform.position = new Vector3(transform.position.x, GameManager.core.minY);
        }
        if (transform.position.y < GameManager.core.minY && transform.position.y != GameManager.core.maxY)
        {
            transform.position = new Vector3(transform.position.x, GameManager.core.maxY);
        }
    }
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
        MoveTowards(controllerToMoveTowards.player);
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
        float randomX = Random.Range(GameManager.core.minX, GameManager.core.maxX);
        float randomY = Random.Range(GameManager.core.minY, GameManager.core.maxY);
        transform.position = new Vector2(randomX, randomY);
    }

    //introduce a bullet movement
    public void Shoot(float bulletSpeed)
    {
        //transform.position = transform.position + (transform.up * bulletSpeed) * Time.deltaTime;
    }
    
    public void FireBullet1()
    {
        spawnPosition = spawnPoint.GetComponent<Transform>();
        GameObject tempBull;
        tempBull = Instantiate(bulletType1, spawnPosition.position, transform.rotation) as GameObject;
        if (tempBull != null)
        {
            Pawn bullComponent = tempBull.GetComponent<Pawn>();
            if (tempBull != null)
            {
                bulletControlToConnect.bull = bullComponent;
            }

        }
    }
    public void FireBullet2()
    {
        spawnPosition = spawnPoint.GetComponent<Transform>();
        GameObject tempBull;
        tempBull = Instantiate(bulletType2, spawnPosition.position, transform.rotation) as GameObject;
        if (tempBull != null)
        {
            Pawn bullComponent = tempBull.GetComponent<Pawn>();
            if (tempBull != null)
            {
                bulletControlToConnect.bull = bullComponent;
            }

        }
    }


}
