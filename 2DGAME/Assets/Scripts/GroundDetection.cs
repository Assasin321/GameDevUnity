using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    [SerializeField] private bool isGround;
    public bool isWallBug;

    public bool isJump => isGround;
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
           
            isGround = !isGround;
           
        }

        if(collision.gameObject.CompareTag("BugWall"))
        {
            isWallBug = !isWallBug;
            Debug.Log("It's Bug");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = !isGround;
        }

        if (collision.gameObject.CompareTag("BugWall"))
        {
            isWallBug = !isWallBug;
        }
    }

}
