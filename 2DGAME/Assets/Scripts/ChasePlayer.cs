using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawn;
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] private float enemySpeed = 7f;
    [SerializeField] private SpawnCollision Enemytrigger;
    [SerializeField] private GameObject clone;
    private int EnemyCount; 
    private Vector3 PlayerPosition;
    private float x;
    [SerializeField] private GameObject enemyTrigger;
    // Start is called before the first frame update


    private void Awake()
    {
        x = Random.Range(1f, 5f);
        Debug.Log(x);
       enemyTrigger.SetActive(false);
        
    }
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (EnemyCount != (int)x && clone == null )
        {
            CloneEnemy();
            
            EnemyCount++;
        }
        if ( clone != null)
        {
            MovetoPlayer();
        }
        if(EnemyCount >= (int)x)
        {
            enemyTrigger.SetActive(true);
        }
        if(Enemytrigger.onTrigger)
        {
            openSpawn();
        }
    }



    public void MovetoPlayer()
    {
        if (player != null)
        {
            PlayerPosition = player.gameObject.transform.position;
            clone.transform.position = Vector2.MoveTowards(clone.transform.position, PlayerPosition, enemySpeed * Time.deltaTime);
        }
        
    }


    public void CloneEnemy()
    {
        clone = Instantiate(EnemyPrefab, spawn.transform.position, Quaternion.identity) as GameObject;
    }

    public void openSpawn()
    {
        spawn.position = new Vector3(spawn.position.x + 15f, spawn.position.y, spawn.position.z);
        Enemytrigger.onTrigger = !Enemytrigger.onTrigger;
        Enemytrigger.transform.position = new Vector3(enemyTrigger.transform.position.x + 14f, enemyTrigger.transform.position.y);
        enemyTrigger.SetActive(false);
        EnemyCount = 0;
        x = Random.Range(1f, 5f);
    }
}
