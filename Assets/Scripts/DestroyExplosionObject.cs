using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosionObject : MonoBehaviour
{

    private float timeTilDestroy = 3f; 

    void Start()
    {

    }

    void Update()
    {
        if(timeTilDestroy <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timeTilDestroy -= Time.deltaTime;
        }
    }
}
