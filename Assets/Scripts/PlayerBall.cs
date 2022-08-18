using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    //Gameobjects and scripts to call
    public LevelLoader levelLoader;
    public ParticleSystem deathParticles;
    public Barrier barrier1;
    public Barrier barrier2;            //Barriers go up to 3 as that is the maximum amount of barriers in any level
    public Barrier barrier3;
    public BallThud ballThud;
    public CameraShake cameraShake;

    //Camera shake variables
    public float cameraShakeduration;
    public float cameraShakeMagnitude;

    //Ball audio variables
    private bool canMakeNoise;

    //Diamond collection and display variables
    public Text diamondNo;
    public int diamondAmount = 0;       //Want to initialise this value as 0 and update later, if need be

    //Highlighting blocks
    public GameObject[] blocks;
    public float highlightRange;
    private GameObject closestBlock;
    public Material originalBlock;
    public Material highlightedBlock;
    private int numHighlighted = 0;
    private float distanceToClosestBlock=100;       //This number is ridiculously high to ensure the program considers every wall in the maze as it iterates through the for loop

    //Placing mines
    private bool canPlaceMine = false;
    private float timeSinceMinePlaced = 0;
    public float timeBetweenMines = 5; 
    public GameObject mine;
    public GameObject floor;
    private GameObject minedWall;
    public Text minesText;
    private int minesAmount = 0;

    //Level management
    private bool gameOver = false;
    

    void Update()
    {
        //Checks whether 1 second has passed since the scene was loaded; this prevents the ball creating a thud sound when the scene starts as that doesn't make sense
        if (Time.timeSinceLevelLoad < 1)    //I hard-coded this as '1' because I do not need to make any modifications to it during the program, so this way is more memory-efficient
        {
            canMakeNoise = false;
        }
        else
        {
            canMakeNoise = true;
        }

        //Calls the method 'FindClosestBlock' every frame to keep track of the closest wall to the ball in the maze, which is then used for highlighting the walls 
        FindClosestBlock();
 

        if (distanceToClosestBlock <= highlightRange)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButton("LBButton") && closestBlock != null)
            {
                HighlightClosestBlock();
                canPlaceMine = true;
            }
            else
            {
                canPlaceMine = false;
            }
        }
        else
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i] != null)
                {
                    blocks[i].GetComponent<Renderer>().material = originalBlock;
                }

            }
        }

        if (timeSinceMinePlaced >= timeBetweenMines)
        {
            if (canPlaceMine && minesAmount > 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("RBButton")))
            {
                minedWall = closestBlock;
                PlaceMine();
                timeSinceMinePlaced = 0f;
            }
        }
        else
        {
            timeSinceMinePlaced += Time.deltaTime;
        }

        if (gameOver == true)
        {
            GameOverSequence();
        }
        minesText.text = "Mines: " + minesAmount;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameOver = true;
        }
        if (other.gameObject.tag == "Diamond")
        {
            CollectDiamond(other);
        }
        if (other.gameObject.tag == "Button")
        {
            if (barrier1 != null)
            {
                barrier1.OpenBarrier();
            }
            
        }
        if (other.gameObject.tag == "Button2")
        {
            if (barrier2 != null)
            {
                barrier2.OpenBarrier();
            }

        }
        if (other.gameObject.tag == "Button3")
        {
            if (barrier3 != null)
            {
                barrier3.OpenBarrier();
            }

        }
        if (other.gameObject.tag == "Mine")
        {
            Destroy(other.gameObject);
            minesAmount += 3;
            minesText.text = "Mines: " + minesAmount;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Wall")
        {
            if (canMakeNoise == true)
            {
                float multiplier = other.relativeVelocity.magnitude;
                ballThud.PlayThud(multiplier);
                StartCoroutine(cameraShake.Shake(cameraShakeduration, cameraShakeMagnitude));
            }
        }
    }

    void CollectDiamond(Collider other)
    {
        Destroy(other.gameObject);
        diamondAmount++;
        //Add one to diamond counter
        diamondNo.text = ("Diamond: " + diamondAmount);
    }

    void FindClosestBlock()
    {
        closestBlock = null;
        distanceToClosestBlock = 100;

        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i] != null)
            {
                float distance = Vector3.Distance(transform.position, blocks[i].transform.position);
                if (distance < distanceToClosestBlock)
                {
                    closestBlock = blocks[i];
                    distanceToClosestBlock = distance;
                }
            }

        }

    }

    void HighlightClosestBlock()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i] != null)
            {
                blocks[i].GetComponent<Renderer>().material = originalBlock;
            }
        }
        closestBlock.GetComponent<Renderer>().material = highlightedBlock;
    }

    void PlaceMine()
    {
        Vector3 minePos = new Vector3(closestBlock.transform.position.x, closestBlock.transform.position.y + 0.59f, closestBlock.transform.position.z);
        Quaternion mineRot = new Quaternion(0f, 0f, 0f, 0f);
        GameObject mineSet = Instantiate(mine, minePos, mineRot);
        mineSet.transform.SetParent(floor.transform);
        mineSet.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        minesAmount--;
    }

    public void DestroyMinedWall()
    {
        print("Destroy wall");
        Destroy(minedWall);
    }

    void GameOverSequence()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);

        // animator.SetBool("gameOver", true);
        Instantiate(deathParticles, pos, Quaternion.identity);
        levelLoader.ReloadLevel();
        gameOver = false;
        Destroy(gameObject);
    }
}

