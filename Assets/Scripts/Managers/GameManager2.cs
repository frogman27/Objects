
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    [Header("Game Enemies")]
    [SerializeField] private GameObject enemyPreFab;
    [SerializeField] private Transform[] spawnPositions;

    [Header("Game Variables")]
    [SerializeField] private float enemySpawnRate;

    private GameObject tempEnemy;
    private bool isEnemySpawning;

    private Weapon meleeWeapon = new Weapon("Melee", 10, 0);

    //Singleton

    private static GameManager2 instance;

    //this is used if any information from the game manager needs to be accessed
    public static GameManager2 GetInstance()
    {
        
        return instance;
    }

    //this is a tool that prevents additional copies of the game manager to be created
    void SetSingleton()
    {
        if (instance != null && instance != this) 
        { 
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    private void Awake()
    {
        SetSingleton();
    }

    void Start()
    {
        isEnemySpawning = true;
        StartCoroutine(SpawnEnemy());
    }

    //Create a random enemy out of the screen

    void CreateEnemy()
    {
        tempEnemy = Instantiate(enemyPreFab);
        tempEnemy.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        tempEnemy.GetComponent<Enemy>().weapon = meleeWeapon;
        tempEnemy.GetComponent<MeleeEnemy>().SetMeleeEnemy(1f, 5f); 
    }

    IEnumerator SpawnEnemy()
    {
        while (isEnemySpawning)
        {
            CreateEnemy();
            yield return new WaitForSeconds(enemySpawnRate);
        }
    }



}
