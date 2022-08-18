using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float openedYLevel = 0.001f;
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 1 , transform.position.z);
    }
    void Update()
    {
        
    }
    public void OpenBarrier()
    {
        Destroy(gameObject);
    }
}
