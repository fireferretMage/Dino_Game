using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_DestroyEverything : MonoBehaviour
{
    GameObject current;
    GameObject[] gameObjects;

    
    private void OnTriggerEnter(Collider col) //trigger events 
    {

        //Destroy(col.gameObject);

        if (col.tag == "Destructible")
        {
            Destroy(col.gameObject);
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
