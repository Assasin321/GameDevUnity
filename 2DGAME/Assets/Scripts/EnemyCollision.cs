using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Player;


public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private bool collision;
    [SerializeField] private GameObject dieEffect;

    // Start is called before the first frame update
    public bool isCollision => collision;

    private float KamikazeDamage = 30f;


    
    private void OnCollisionEnter2D(Collision2D col)
    {

        
            if (col.gameObject.CompareTag("Player"))
            {
                PlayerScript player = col.gameObject.GetComponent<PlayerScript>();
            if (gameObject.tag.Equals("Enemy"))
                    {
                        if (player.playerMain.GetPlayerArmor() > 0)
                        {
                            player.playerMain.DamagePlayerArmor(KamikazeDamage);
                        }
                        else
                        {
                            player.playerMain.DamagePlayerHealth(KamikazeDamage);
                            if(player.playerMain.GetPlayerHealth() <= 0)
                    {
                        Destroy(col.gameObject);
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                    }
                            
                        }
                Die();
            }
            if(col.gameObject != null)
            {
                player.MainPlayerHealth();
                KamikazeDamage = Random.Range(30f, 40f);
            }
             
             

            }
        
       
    }
    void Die()
    {
        if (dieEffect != null)
        {
            Instantiate(dieEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }




}
