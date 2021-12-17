using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Health;
using Player;
namespace Enemy
{
    public class Enemy
    {
        public Health.Health enemyHealth = new Health.Health();

        public Enemy()
        {
            enemyHealth.SetHealth(50);
        }

        public float GetEnemyHealth()
        {
            return enemyHealth.GetHealth;
        }

        public void DamageEnemyHealth(float damage)
        {
            enemyHealth.DamageHealth(damage);
        }
    }
    public class EnemyScript : MonoBehaviour
    {
        public Enemy enemy = new Enemy();
        public float PlayerDamage = 10f;

        private void Awake()
        {

          


            
        }

        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {

         

        }

        private void FixedUpdate()
        {
         
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Bullet"))
            {
                enemy.DamageEnemyHealth(PlayerDamage);
                Debug.Log(enemy.enemyHealth.GetHealth);
                if(enemy.enemyHealth.GetHealth <= 0)
                {
                    Destroy(gameObject);
                    
                }
            }
        }


    }




}
