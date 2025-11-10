using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class SpawnHazards : MonoBehaviour
{

    public GameObject asteroidToSpawn;
    public GameObject uFOToSpawn;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn(spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

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

}

