using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnHazards : MonoBehaviour
{
    [Header("bools")]
    public bool isActive;

    [Header("assets")]
    public static SpawnHazards spawner;
    public GameObject asteroidToSpawn;
    public GameObject babiesToSpawn;
    public GameObject uFOToSpawn;
    public GameObject HIM;
    public EnemyController controllerToGrab;
    public GameObject gameplay;
    int randomCount;
    public float randomChance;

    [Header("Location")]
    public float spawnTime;
    float minX = -10f;
    float maxX = 10f;
    float minY = -5f;
    float maxY = 5f;
    public Vector3 spawnPosition;
    public Vector3 spawnBabyPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if (spawner == null)
        {
            spawner = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Spawn(spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.core.Score >= GameManager.core.vicScore && isActive != true)
        {
            isActive = true;
            BossSpawn();
        }
    }
    
    public void BossSpawn()
    {
        if (controllerToGrab.him == null)
        {
            GameObject bossTemp;
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            spawnPosition = new Vector3(randomX, randomY, 0);

            bossTemp = Instantiate(HIM, spawnPosition, Quaternion.identity) as GameObject;

            if (controllerToGrab.him != null)
            {
                Pawn pawnComponent = bossTemp.GetComponent<Pawn>();

                if (bossTemp != null)
                {
                    controllerToGrab.him = pawnComponent;
                    bossTemp.transform.parent = gameplay.transform;
                }
            }
        }
    }
    void Spawn(float spawnTime)
    {
        StartCoroutine(SpawnHazard());
    }
    public IEnumerator SpawnHazard()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            randomChance = Random.Range(1, 5);
            if (randomChance > 3)
            {
                if (GameManager.core.uFOsInPlay.Count <= 1)
                {

                    randomCount = Random.Range(GameManager.core.minSpawn, GameManager.core.maxSpawns + 1);
                    if (GameManager.core.secret.Count == 0)
                    {
                        float randomX = Random.Range(minX, maxX);
                        float randomY = Random.Range(minY, maxY);
                        spawnPosition = new Vector3(randomX, randomY, 0);

                        GameObject tempUFO;
                        tempUFO = Instantiate(uFOToSpawn, spawnPosition, Quaternion.identity) as GameObject;
                        Pawn pawnComponent = tempUFO.GetComponent<Pawn>();
                        if (tempUFO != null)
                        {
                            controllerToGrab.uFO = pawnComponent;
                            tempUFO.transform.parent = gameplay.transform;

                        }
                    }
                    else
                    {
                        for (int i = 0; i < randomCount; ++i)
                        {
                            float randomX = Random.Range(minX, maxX);
                            float randomY = Random.Range(minY, maxY);
                            spawnPosition = new Vector3(randomX, randomY, 0);
                            GameObject tempUFO;
                            tempUFO = Instantiate(uFOToSpawn, spawnPosition, Quaternion.identity) as GameObject;
                            Pawn pawnComponent = tempUFO.GetComponent<Pawn>();
                            if (tempUFO != null)
                            {
                                controllerToGrab.uFO = pawnComponent;
                                tempUFO.transform.parent = gameplay.transform;
                            }
                        }
                    }
                }
            }
            else
            {
                if (GameManager.core.asteroidsInPlay.Count <= 1)
                {

                    randomCount = Random.Range(GameManager.core.minSpawn, GameManager.core.maxSpawns + 1);
                    if (GameManager.core.secret.Count == 0)
                    {
                        float randomX = Random.Range(minX, maxX);
                        float randomY = Random.Range(minY, maxY);
                        spawnPosition = new Vector3(randomX, randomY, 0);

                        GameObject tempAsteroid;
                        tempAsteroid = Instantiate(asteroidToSpawn, spawnPosition, Quaternion.identity) as GameObject;
                        Pawn pawnComponent = tempAsteroid.GetComponent<Pawn>();
                        if (tempAsteroid != null)
                        {
                            controllerToGrab.asteroid = pawnComponent;
                            tempAsteroid.transform.parent = gameplay.transform;

                        }
                    }
                    else
                    {
                        for (int i = 0; i < randomCount; ++i)
                        {
                            float randomX = Random.Range(minX, maxX);
                            float randomY = Random.Range(minY, maxY);
                            spawnPosition = new Vector3(randomX, randomY, 0);
                            GameObject tempAsteroid;
                            tempAsteroid = Instantiate(asteroidToSpawn, spawnPosition, Quaternion.identity) as GameObject;
                            Pawn pawnComponent = tempAsteroid.GetComponent<Pawn>();
                            if (tempAsteroid != null)
                            {
                                controllerToGrab.asteroid = pawnComponent;
                                tempAsteroid.transform.parent = gameplay.transform;
                            }
                        }
                    }
                }
            
            }
        }
        
    }
    public void SpawnChildren()
    {
        randomCount = Random.Range(GameManager.core.minSpawn+ 1, GameManager.core.maxSpawns + 1);
        for (int i = 0; i < randomCount; ++i)
        {
            GameObject tempBabyAsteroid;
            tempBabyAsteroid = Instantiate(babiesToSpawn, spawnBabyPos, Quaternion.identity) as GameObject;
            Pawn pawnComponent = tempBabyAsteroid.GetComponent<Pawn>();
            if (tempBabyAsteroid != null)
            {
                controllerToGrab.baby = pawnComponent;
                tempBabyAsteroid.transform.parent = gameplay.transform;
            }
        }
    }

}

