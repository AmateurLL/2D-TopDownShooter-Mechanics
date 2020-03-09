using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    [Header("Stat")]
    [SerializeField] public float spawnTimer = 0.0f;
    [SerializeField] public float spawnTime = 3.0f;
    [SerializeField] private float spawnDistRange = 50.0f;

    private float spawnRangeX;
    private float spawnRangeY;
    private Vector3 spawnTransform;

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
            //CalculateSpawnPosition();
            GameObject tempMob = Instantiate(PrefabManager.Instance.m_ZombieRef, spawnTransform, transform.rotation);
            Debug.Log("Zombie poop");

            // Reset Timer
            spawnTimer = spawnTime;
        }

    }
    /*
    Transform CalculateSpawnPosition(){
        // Testing
        spawnTransform.position = new Vector3(spawnDistRange, 0.0f, 0.0f);
        return(spawnTransform);
    }
    */
}
