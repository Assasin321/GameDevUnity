using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootingScript : MonoBehaviour
{
    [SerializeField] private float shootSpeed, shootTimer;
    private bool isShooting;

    public SpriteRenderer SpriteRenderer;

    [SerializeField]  Sprite Sam2;
    [SerializeField]  Sprite Sam1;

    [SerializeField] private Text ammu;

    public Transform shootPos;
    public GameObject bullet;

    //public GameObject enemyTrigger;

    private float ammo;

    // Start is called before the first frame update


    private void Awake()
    {
        ammo = 50f;
        ammu.text = "AMMO: " + ammo.ToString();
    }
    void Start()
    {
        isShooting = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            if(ammo > 0)
            {
                SpriteRenderer.sprite = Sam2;
                StartCoroutine(Shoot());
            }
            
            
        }

    }

    IEnumerator Shoot()
    {

        int direction()
        {
            if(transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }
        isShooting = true;

        ammo -= 1;
        ammu.text = "AMMO: " + ammo.ToString();
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
        SpriteRenderer.sprite = Sam1;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ammo"))
        {
            if(ammo < 50f)
            {
                ammo += 5f;
                ammu.text = "AMMO: " + ammo.ToString();
            }
            
        }
    }



}
