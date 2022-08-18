using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform enemyStart;
    public Transform enemyDest;
    private bool goToStart;
    private bool goToDest;
    public float speed;

    void Start()
    {
        transform.position = enemyStart.position;
        goToDest = true;
    }

    void Update()
    {
        if (goToStart == true)
        {
            GoToStart();
        }
        else if (goToDest == true)
        {
            GoToDest();
        }
    }
    void GoToDest()
    {
        if (transform.position != enemyDest.position)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, enemyDest.transform.position, speed * Time.deltaTime);
        }
        else
        {
            goToDest = false;
            goToStart = true;
        }
        
    }
    void GoToStart()
    {
        if (transform.position != enemyStart.position)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, enemyStart.transform.position, speed * Time.deltaTime);
        }
        else
        {
            goToStart = false;
            goToDest = true;
        }
    }
}
