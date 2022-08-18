using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float timeTilDestroy = 1.5f;

    void Update()
    {
        if (timeTilDestroy <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timeTilDestroy -= Time.deltaTime;
        }
    }

}
