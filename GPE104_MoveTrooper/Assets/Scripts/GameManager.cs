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

    [Header("misc")]
    public List<DamageOnEnter> damageZones;

    [Header("Timer")]
    public float timeRemaining;
    public float maxTime;

    [Header("Score")]
    public int Score = 0;

    [Header("Audio")]

    public AudioClip shootSFX;
    public AudioClip deathSFX;
    public AudioClip explosionSFX;




    void Awake()
    {
        if (core == null)
        {
            core = this;
        } else
        {
            Destroy(gameObject);
        }

        damageZones = new List<DamageOnEnter>();
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
      if (damageZones != null)
        {
            WinGame();
        }
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
        if (damageZones.Count <= 0)
        {
            Debug.Log("Victory | I soar above all.");
        }
    }

    
    public void LoseGame()
    {
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
}
