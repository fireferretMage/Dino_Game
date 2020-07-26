using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Spawner : MonoBehaviour
{

    public GameObject itemsToPickFrom;
    public GameObject spawnPoint;
    public float levelSpeed;
    private Vector3 spawnVector;
    public Vector3 spawnSize = new Vector3 (1f, 1f, 1f);


    // Start is called before the first frame update
    void Awake()
    {
        
        spawnVector = gameObject.transform.position;
        itemsToPickFrom.transform.localScale = spawnSize;

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
