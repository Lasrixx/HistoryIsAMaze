using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    public GameObject[] enemyPoints;
    private int index;
    public float speed;
    void Start()
    {
        index = 1;
        transform.position = enemyPoints[0].transform.position;
    }


    void Update()
    {
        Move();

    }
    void Move()
    {
        if (transform.position != enemyPoints[index].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyPoints[index].transform.position, speed * Time.deltaTime);
        }
        if (transform.position == enemyPoints[index].transform.position)
        {
            if (index < enemyPoints.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
    }
}
