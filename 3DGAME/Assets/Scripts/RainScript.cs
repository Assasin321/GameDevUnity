using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{

    public ParticleSystem particleSystem;
    public Terrain terrain;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem.Play();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
