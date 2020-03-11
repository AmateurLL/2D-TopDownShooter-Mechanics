using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    [Header("Stat")]
    [SerializeField] public float spawnTimer = 0.0f;
    [SerializeField] public float spawnTime = 3.0f;
    [SerializeField] private float spawnDistRange = 10.0f;

    private int spawnDirX;
    private int spawnDirY;
    private float spawnRangeX;
    private float spawnRangeY;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        Spawner();
    }

    void Spawner(){

        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0.0f){
            // Spawn Zombie
            CalculateSpawnPosition();
            GameObject tempMob = Instantiate(PrefabManager.Instance.m_ZombieRef, spawnPosition, Quaternion.identity);
            //Debug.Log("Zombie poop");

            // Reset Timer
            spawnTimer = spawnTime;
        }

    }
    
    // Basic Spawn algorithm for spawning around a targeted origin point
    Vector3 CalculateSpawnPosition(){
        // Checking which the direction the spawn positoino shoul be
        // Making sure it doesnt return with 0 
        spawnDirX = Random.Range(-1, 2);
        spawnDirY = Random.Range(-1, 2);
        while(spawnDirX == 0){
            spawnDirX = Random.Range(-1, 1);
        }
        while(spawnDirY == 0){
            spawnDirY = Random.Range(-1, 1);
        }

        spawnRangeX = (spawnDistRange + (Random.Range(1.0f, 10.0f))) * (float)spawnDirX;
        spawnRangeY = (spawnDistRange + (Random.Range(1.0f, 10.0f))) * (float)spawnDirY;

        // Testing
        spawnPosition = new Vector3(spawnRangeX, spawnRangeY, 0.0f);
        //Debug.Log(spawnPosition);
        return(spawnPosition);
    }
    
}
