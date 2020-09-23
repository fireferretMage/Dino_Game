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
    private Collider lastSpawnedCollider;
    public Vector3 lastSpawnedBoundsVector;

    public GameObject PlatformDestroyer;
    private bool isPlatformDestroyer = false;

    public int maxGroundSpawnNumber = 10;

    public int groundpickNumber = 0;
    

    public void spawnGround ()
    {
        
        Debug.Log(groundCounter);

        _intRandomGroundThree = randomGroundThree.Next(groundpickNumber, groundpickNumber + 3);
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

        GameObject newGameObject = Instantiate (groundPrefab[_intRandomGroundThree], new Vector3(0f + lastSpawnedBoundsVector.x, 0f, 0f), Quaternion.Euler(0f, groundRotation, 0f));
        newGameObject.GetComponent<CS_GroundLevelSpeed>().Init(lastSpawned);
        lastSpawned = newGameObject; //find last spawned object
        lastSpawnedCollider = lastSpawned.GetComponent<Collider>(); //get last spawned objects to collider
        lastSpawnedBoundsVector = lastSpawnedCollider.bounds.size; //convert last spawned objects collider to Vector3 then minus the spawn position by half the amount to have a seamless loop
        

        if (isPlatformDestroyer == false)
        {
            Instantiate(PlatformDestroyer, new Vector3(lastSpawnedBoundsVector.x * 7 - 620f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));

            isPlatformDestroyer = true;
        }
        groundCounter++;
    }


    // Update is called once per frame
    public void Update()
    {

        if (groundCounter <= maxGroundSpawnNumber)
        {
            spawnGround();

            //groundMinus = groundMinus + 270.07f;
            
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
