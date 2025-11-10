using UnityEngine;
using System.Collections;

public class SpawnHazards : MonoBehaviour
{

    public GameObject asteroidToSpawn;
    public GameObject uFOToSpawn;
    public EnemyController controllerToGrab;
    public GameObject gameplay;
    int randomCount;

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
        randomCount = Random.Range(3, 10);
        for (int i = 0; i < randomCount; ++i)
        {

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

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn(float spawnTime)
    {
        StartCoroutine(SpawnUFO());
    }
    public IEnumerator SpawnUFO()
    {
        while (true)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            spawnPosition = new Vector3(randomX, randomY, 0);
            randomCount = Random.Range(1, 3);

            if (GameManager.core.uFOsInPlay.Count <= 1)
            {
                yield return new WaitForSeconds(spawnTime);
                if (GameManager.core.secret.Count == 0)
                {
                    for (int i = 0; i < 2; ++i)
                    {

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
                else
                {
                    for (int i = 0; i < randomCount; ++i)
                    {

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
        
    }
   
    public void SpawnAsteroid()
    {

    }
}
