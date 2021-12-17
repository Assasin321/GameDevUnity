using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCollision : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    private bool isNext = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            if(isNext)
            {
                cameraTransform.transform.position += new Vector3(18f, 0);
                isNext = !isNext;
            }
            else
            {
                cameraTransform.transform.position += new Vector3(-18f, 0);
                isNext = !isNext;
            }
            
        }
    }
}
