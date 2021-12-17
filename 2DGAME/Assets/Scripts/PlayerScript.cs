using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Health;
using UnityEngine.SceneManagement;

namespace Player
{
    public class Player
    {
        public Health.Health playerHealth = new Health.Health();
        public Player()
        {
            playerHealth.SetHealth(100);
            playerHealth.SetArmor(100);
            playerHealth.CareHealth(20);
        }

        public float GetPlayerHealth()
        {
           return playerHealth.GetHealth;
        }

        public void DamagePlayerHealth(float damage)
        {
            playerHealth.DamageHealth(damage);
        }
        public float GetPlayerArmor()
        {
           return playerHealth.GetArmor;
        }

        public void DamagePlayerArmor(float damage)
        {
            playerHealth.DamageArmor(damage);
        }
     

    }


    public class PlayerScript : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D Rigidbody;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpSpeed = 1f;
        [SerializeField] private Text h;
        [SerializeField] private Text a;
        [SerializeField] private Text Finish;
        [SerializeField] private GroundDetection groundDetection;
        public Player playerMain = new Player();

        // Start is called before the first frame update

        private void Awake()
        {
            MainPlayerHealth();
            Finish.text = "For Quit ALT + F4";

        }

        void Start()
        {

            

        }

        // Update is called once per frame
        void Update()
        {
            MovePlayer();

        }

        private void FixedUpdate()
        {
            Jump();
        }



        private void MovePlayer()
        {
            var horizontalInput = Input.GetAxisRaw("Horizontal");

            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
                Finish.text = "";
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
                Finish.text = "";
            }

            if(groundDetection.isWallBug)
            {
                speed = 0;
                GoBack();
            }
            

            Rigidbody.velocity = new Vector2(horizontalInput * speed, Rigidbody.velocity.y);

        }

        private void Jump()
        {
            if (Input.GetButton("Jump") && groundDetection.isJump ){
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
                Rigidbody.velocity += jumpVelocityToAdd;
            }
        }

        public void MainPlayerHealth()
        {
            if(playerMain.playerHealth.GetHealth > 0 && playerMain.playerHealth.GetArmor > 0)
            {
                h.text = "HEALTH: " + playerMain.playerHealth.GetHealth.ToString();
                a.text = "ARMOR: " + playerMain.playerHealth.GetArmor.ToString();
            }
            if(playerMain.playerHealth.GetArmor <= 0 && playerMain.playerHealth.GetHealth > 0)
            {
                h.text = "HEALTH: " + playerMain.playerHealth.GetHealth.ToString();
                a.text = "ARMOR: 0 " ;
            }
            if(playerMain.playerHealth.GetHealth <= 0)
            {
                h.text = "HEALTH: 0 ";
                a.text = "ARMOR: 0 ";
            }
            
        }

        public void GoBack()
        {
            transform.position = new Vector3(-2f, 0f);
            speed = 5f;
        }


       

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Finish"))
            {
                Finish.text = "You Win";
                SceneManager.LoadScene("Quit");
            }
        }

        public void JustFinish()
        {
            //
            
        }
        
    }
    
    
}
