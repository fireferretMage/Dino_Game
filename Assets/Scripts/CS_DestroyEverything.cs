using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_DestroyEverything : MonoBehaviour
{
    
    GameObject[] gameObjects;
    public CS_Spawner Spawner;

    public void OnTriggerEnter(Collider col) //trigger events 
    {

        //Destroy(col.gameObject);

        if (col.tag == "Destructible")
        {
            Destroy(col.gameObject);

            Spawner.groundCounter -= 1;
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
