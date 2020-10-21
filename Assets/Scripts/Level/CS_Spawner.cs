using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class CS_Spawner : MonoBehaviour
{
    private System.Random randomTwo = new System.Random();
    private System.Random randomGroundThree = new System.Random();


    private int _intRandomGroundThree;
    private int _intRandomTwo;

    private float groundRotation;

    CS_GroundLevelSpeed GroundLevelSpeed;


    public static float levelSpeed = 15000f;

    public GameObject[] groundPrefab;
    public int groundCounter = 0;
    public int maxGroundSpawnNumber = 10;
    public int groundpickNumber = 0;


    private float groundMinus;

    private GameObject lastSpawned;
    private Collider lastSpawnedCollider;
    public Vector3 lastSpawnedBoundsVector;

    public GameObject PlatformDestroyer;
    private bool isPlatformDestroyer = false;

    private System.Random randomThreatThree = new System.Random();
    public GameObject[] ThreatPrefab;
    public int threatCounter = 0;
    public int maxThreatSpawnCounter = 3;
    public float spawnTime;
    public float spawnDelay;

    private System.Random randSpawnDelay = new System.Random();
    private System.Random randRotation = new System.Random();
    float randSpawnDelayfloat;


    public int maxMountains = 10;
    public int mountainCounter = 0;
    public GameObject[] mountainPrefab;

    private System.Random randomMountainThree = new System.Random();
    private System.Random randomMountainTwo = new System.Random();
    float MountainRotation = 180f;

    private GameObject lastSpawnedMountain;
    private Collider lastSpawnedColliderMountain;
    public Vector3 lastSpawnedBoundsVectorMountain;

    private bool isMountainDestroyer = false;

    public void spawnGround ()
    {
        //Debug.Log(groundCounter);

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

        GameObject PlatformObj = Instantiate (groundPrefab[_intRandomGroundThree], new Vector3(0f + lastSpawnedBoundsVector.x, 0f, 0f), Quaternion.Euler(0f, groundRotation, 0f));
        PlatformObj.GetComponent<CS_GroundLevelSpeed>().Init(lastSpawned);
        lastSpawned = PlatformObj; //find last spawned object
        lastSpawnedCollider = lastSpawned.GetComponent<Collider>(); //get last spawned objects to collider
        lastSpawnedBoundsVector = lastSpawnedCollider.bounds.size; //convert last spawned objects collider to Vector3 then minus the spawn position by half the amount to have a seamless loop
        

        if (isPlatformDestroyer == false)
        {
            Instantiate(PlatformDestroyer, new Vector3(lastSpawnedBoundsVector.x * 7 - 620f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));

            isPlatformDestroyer = true;
        }

        groundCounter++;  //add it at the end after you spawn the last one so it becomes a treadmill

    }




    public void spawnThreat ()
    {
        

        int _intrandomThreatThree = randomThreatThree.Next(0, 4);

        randSpawnDelayfloat = randSpawnDelay.Next(5, 10);
        Debug.Log(randSpawnDelayfloat);

        if (threatCounter >= maxThreatSpawnCounter)
        {

        }

        int randThreatRotationint = randRotation.Next(0, 360);

        Debug.Log(randThreatRotationint);

        GameObject newThreatObject = Instantiate(ThreatPrefab[_intrandomThreatThree], new Vector3(0f - 1500f, 0f, 0f), Quaternion.Euler(0f, randThreatRotationint, 0f));

        threatCounter++;

        

    }

    public void spawnMountain()
    {
        //Debug.Log(groundCounter);

        int _intRandomMountainThree = randomMountainThree.Next(0 , 3);
        int _intRandomMountainTwo = randomMountainTwo.Next(0, 2);
        //Debug.Log(_intRandomTwo);
        

        if (_intRandomMountainTwo == 0)
        {
            MountainRotation = 0f;
        }
        else
        {
            MountainRotation = 180f;
        }

        GameObject MountainObj = Instantiate(mountainPrefab[_intRandomMountainThree], new Vector3(lastSpawnedBoundsVectorMountain.x, 0f, -630f), Quaternion.Euler(0f, MountainRotation, 0f));
        MountainObj.GetComponent<CS_Mountain>().InitMountain(lastSpawnedMountain);
        lastSpawnedMountain = MountainObj; //find last spawned object
        lastSpawnedColliderMountain = lastSpawnedMountain.GetComponent<Collider>(); //get last spawned objects to collider
        lastSpawnedBoundsVectorMountain = lastSpawnedColliderMountain.bounds.size; //convert last spawned objects collider to Vector3 then minus the spawn position by half the amount to have a seamless loop


    //private GameObject lastSpawnedMountain;
    //private Collider lastSpawnedColliderMountain;
    //public Vector3 lastSpawnedBoundsVectorMountain;

        if (isMountainDestroyer == false)
        {
            Instantiate(PlatformDestroyer, new Vector3(lastSpawnedBoundsVectorMountain.x * 7 - 620f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));

            isMountainDestroyer = true;
        }

        mountainCounter++;

    }

    // Update is called once per frame
    public void Update()
    {



        if (groundCounter <= maxGroundSpawnNumber)
        {
            spawnGround();

            //groundMinus = groundMinus + 270.07f;
        }
        else { }

        if (mountainCounter <= maxMountains)
        {
            spawnMountain();

        }
        else { }

    }

    private void Start()
    {



        if (threatCounter == 0)
        {

            InvokeRepeating("spawnThreat", spawnTime, randSpawnDelayfloat + 1);

        }
        else
        {
            CancelInvoke("spawnThreat");
        }
    }




    /* 
    How to use random

    int month = rnd.Next(1, 13);  // creates a number between 1 and 12
    int dice = rnd.Next(1, 7);   // creates a number between 1 and 6
    int card = rnd.Next(52);     // creates a number between 0 and 51
    */


}
