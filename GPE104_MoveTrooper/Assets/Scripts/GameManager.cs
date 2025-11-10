using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager core;

    [Header("Scenes")]
    public GameObject Gameplay;
    public GameObject Title;
    public GameObject Victory;
    public GameObject Lose;
    public Controller enemyController;
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    [Header("Secret")]
    public GameObject secretHim;
    public List<SecretCounter> secret;


    [Header("Hazards")]
    public List<DamageOnEnter> damageZones;
    public List<DamageOnEnter> uFOsInPlay;
    public List<DamageOnEnter> asteroidsInPlay;
    public int minSpawn;
    public int maxSpawns;

    [Header("Timer")]
    public float timeRemaining;
    public float maxTime;

    [Header("Score")]
    public int Score = 0;
    public bool winCondition;
    public int Lives;

    [Header("Audio")]

    // Get sound from freesound.org Kenny.nl
    public AudioClip shootSFX;
    public AudioClip collisionSFX;
    public AudioClip passiveHum;
    public AudioClip deathSFX;
    public AudioClip explosionSFX;
    public AudioClip BackgroundMusic;
    public AudioClip TitleMusic;




    void Awake()
    {
        if (core == null)
        {
            core = this;
        } 
        else
        {
            Destroy(gameObject);
        }

        damageZones = new List<DamageOnEnter>();
        uFOsInPlay = new List<DamageOnEnter>();
        asteroidsInPlay = new List<DamageOnEnter>();
        secret = new List<SecretCounter>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartTitle();
        timeRemaining = maxTime;
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
      if (Score >= 100 && winCondition == true)
        {
            WinGame();
        }
      //if (secret != null)
      //  {
      //      SecretSpawn();
      //  }
    }

    public void GameQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void StartGame()
    {
        StartGameplay();
        timeRemaining = maxTime;
        ResetScore();
    }
    public void WinGame()
    {
        if (Title.activeSelf != true)
        {
            Debug.Log("Victory | I soar above all.");
            StartVictory();
        }
    }

    
    public void SecretSpawn()
    {

        if (enemyController.secret == null)
        {
            GameObject secretTemp;

            secretTemp = Instantiate(secretHim, Vector3.zero, Quaternion.identity) as GameObject;

            if (enemyController.secret != null)
            {
                Pawn pawnComponent = secretTemp.GetComponent<Pawn>();

                if (secretTemp != null)
                {
                    enemyController.secret = pawnComponent;
                    secretTemp.transform.parent = Gameplay.transform;
                }
            }
        }
    }
    public void LoseGame()
    {
        StartLose();
        Debug.Log("Failure | How have I fallen?");
    }
    
    public void ResetScore()
    {
        Score.ToString();
    }
    public void ResetTimer()
    {
        timeRemaining = maxTime;
    }
    


    //deactive scenes
    private void DeactivateScenes()
    {
        Title.SetActive(false);
        Gameplay.SetActive(false);
        Victory.SetActive(false);
        Lose.SetActive(false);
    }
    public void StartLose()
    {
        DeactivateScenes();
        Lose.SetActive(true);
    }
    public void StartTitle()
    {
        DeactivateScenes();

        Title.SetActive(true);
    }
    public void StartGameplay()
    {
        DeactivateScenes();
        Gameplay.SetActive(true);
    }
    public void StartVictory()
    {
        DeactivateScenes();
        Victory.SetActive(true);
    }
}
