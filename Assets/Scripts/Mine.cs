using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float timeToDetonation = 3f;
    public ParticleSystem mineExplosion;
    public PlayerBall destroyWall;
    public float explosionRadius = 0.00001f;
    public GameObject explosionSound;
    private bool canExplode;

    void Start()
    {
        canExplode = true;
    }


    void Update()
    {
        if (timeToDetonation <= 0f)
        {
            if (canExplode)
            {
                Explode();
                canExplode = false;
            }

        }
        else
        {
            timeToDetonation -= Time.deltaTime;
        }
    }

    void Explode()
    {
        Collider[] wallsToExplode = Physics.OverlapSphere(transform.position, 0.1f);    //explosionRadius destroys more than one at 0.00001f, but if manually set like is then does only destroy one
        foreach (Collider wall in wallsToExplode)
        {
            WallDestroy wallDestroy = wall.GetComponent<WallDestroy>();
            if (wallDestroy != null)
            {
                wallDestroy.DestroyWall();
            }
        }

        Instantiate(mineExplosion, transform.position, Quaternion.identity);
        //destroyWall.DestroyMinedWall();
        Instantiate(explosionSound, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
}
