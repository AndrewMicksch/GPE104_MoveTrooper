using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager core;

    public List<DamageOnEnter> damageZones;

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
    public void WinGame()
    {
        if (damageZones.Count <= 0)
        {
            Debug.Log("I soar above all.");
        }
    }

    
    public void LoseGame()
    {
        Debug.Log("How have I fallen?");
    }
    
}
