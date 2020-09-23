using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_DestroyEverything : MonoBehaviour
{
    
    GameObject[] gameObjects;
    public CS_Spawner Spawner;

    public void Awake()
    {
        Spawner = GameObject.Find("Level Spawner").GetComponent(typeof(CS_Spawner)) as CS_Spawner;
    }

    

    public void OnTriggerEnter(Collider col) //trigger events 
    {

        //Destroy(col.gameObject);

        if (col.tag == "Platform")
        {
            Spawner.groundCounter -= 1;
            Destroy(col.gameObject);

            
            Debug.Log(Spawner.groundCounter);
            
        }

    }

    /*
    void Update()
    {
        current = GameObject.FindWithTag("Destructible");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
            //Debug.Log(gameObjects);
        }
    }
    */
}
