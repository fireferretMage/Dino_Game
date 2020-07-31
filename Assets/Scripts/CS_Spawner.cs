using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CS_Spawner : MonoBehaviour
{
    private System.Random randomTwo = new System.Random();
    private System.Random randomGroundThree = new System.Random();

    private int _intRandomGroundThree;
    private int _intRandomTwo;

    private float groundRotation;

    public GameObject[] groundPrefab;
    

    public static float levelSpeed = 20000f;

    public int groundCounter = 0;
    private float groundMinus;

    private GameObject lastSpawned;

    //public GameObject spawnPoint;
    //public static Vector3 spawnSize = new Vector3(1f, 1f, 1f);
    //[SerializeField] private Vector3 spawnVector = new Vector3(-520f, 0f,0f);





    public void Awake()
    {
        //gameObject.transform.position = spawnVector;
        //itemsToPickFrom.transform.localScale = spawnSize;

        
        //Mathf.Round(1f,0f); //this one

        //new [] groundPrefab.transform.rotaion =  //Math.Round(Decimal, rnd); //round the random number produced by CS_Random.rnd
    }

    public void spawnGround ()
    {
        groundCounter++;

        _intRandomGroundThree = randomGroundThree.Next(0, 3);
        _intRandomTwo = randomTwo.Next(0, 2);
        //Debug.Log(_intRandomTwo);

        if (_intRandomTwo == 0)
        {
            groundRotation = 0f;
        }
        else 
        {
            groundRotation = 180f;
        }
        GameObject newGameObject = Instantiate (groundPrefab[_intRandomTwo], new Vector3(-620f, 0f, 0f), Quaternion.Euler(0f, groundRotation, 0f));
        newGameObject.GetComponent<CS_GroundLevelSpeed>().Init(lastSpawned);
        lastSpawned = newGameObject;

    }

    // Update is called once per frame
    public void Update()
    {

        if (groundCounter <= 5)
        {
            spawnGround();

            groundMinus = groundMinus + 270.07f;

        }


        //groundPrefab.transform.position.y = groundRotation;
    }

    /* 
    How to use random

    int month = rnd.Next(1, 13);  // creates a number between 1 and 12
    int dice = rnd.Next(1, 7);   // creates a number between 1 and 6
    int card = rnd.Next(52);     // creates a number between 0 and 51
    */


}
