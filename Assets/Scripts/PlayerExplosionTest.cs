using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosionTest : MonoBehaviour
{
    public int particleNum;
    public GameObject particle;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Explosion();
        }
    }

    void Explosion()
    {
        for (int i = 0; i < particleNum; i++)
        {
            Quaternion rot = new Quaternion(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180), Random.Range(0,180));
            Instantiate(particle, transform.position, transform.rotation);
            
        } 
    }
}
