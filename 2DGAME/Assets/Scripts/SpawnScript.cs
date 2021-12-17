using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] SpawnCollision spawnCollision;
    public GameObject clone;
    
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnEnemy()
    {
          


       clone = Instantiate(EnemyPrefab, transform.position, Quaternion.identity) as GameObject;
            spawnCollision.onTrigger = !spawnCollision.onTrigger;
        
            

    }


    
}
